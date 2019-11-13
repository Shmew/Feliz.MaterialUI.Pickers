module App

open Elmish
open Elmish.React
open Fable.React
open Feliz
open Feliz.Markdown
open Fable.SimpleHttp
open Feliz.Router
open Fable.Core
open Fable.Core.JsInterop
open Zanaptak.TypedCssClasses

type Bulma = CssClasses<"https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.5/css/bulma.min.css", Naming.PascalCase>
type FA = CssClasses<"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", Naming.PascalCase>

type Highlight =
    static member inline highlight (properties: IReactProperty list) =
        Interop.reactApi.createElement(importDefault "react-highlight", createObj !!properties)

type State = 
    { CurrentPath : string list
      CurrentTab: string list }

let init () = 
    { CurrentPath = [ ]
      CurrentTab = [ ] }, Cmd.none

type Msg =
    | TabToggled of string list
    | UrlChanged of string list

let update msg state =
    match msg with
    | UrlChanged segments -> 
        { state with CurrentPath = segments }, 
        match state.CurrentTab with
        | [ ] when segments.Length > 2 -> 
            segments
            |> TabToggled
            |> Cmd.ofMsg
        | _ -> Cmd.none
    | TabToggled tabs ->
        match tabs with
        | [ ] -> { state with CurrentTab = [ ] }, Cmd.none
        | _ -> { state with CurrentTab = tabs }, Cmd.none

let centeredSpinner =
    Html.div [
        prop.style [
            style.textAlign.center
            style.marginLeft length.auto
            style.marginRight length.auto
            style.marginTop 50
        ]
        prop.children [
            Html.li [
                prop.className [
                    FA.Fa
                    FA.FaRefresh
                    FA.FaSpin
                    FA.Fa3X
                ]
            ]
        ]
    ]

let samples = 
    [ "pickers-date-basic", Samples.Date.Basic.render()
      "pickers-date-keyboardinput", Samples.Date.KeyboardInput.render()
      "pickers-date-differentviews", Samples.Date.DifferentViews.render()
      "pickers-date-inlinemode", Samples.Date.InlineMode.render()
      "pickers-date-staticmode", Samples.Date.StaticMode.render()
      "pickers-date-customization", Samples.Date.Customization.render()
      "pickers-date-dynamicdata", Samples.Date.DynamicData.render() ]

let githubPath (rawPath: string) =
    let parts = rawPath.Split('/')
    if parts.Length > 5
    then sprintf "http://www.github.com/%s/%s" parts.[3] parts.[4]
    else rawPath

/// Renders a code block from markdown using react-highlight.
/// Injects sample React components when the code block has language of the format <language>:<sample-name>
let codeBlockRenderer (codeProps: Markdown.ICodeProperties) =
    if codeProps.language <> null && codeProps.language.Contains ":" then
        let languageParts = codeProps.language.Split(':')
        let sampleName = languageParts.[1]
        let sampleApp =
            samples
            |> List.tryFind (fun (name, _) -> name = sampleName)
            |> Option.map snd
            |> Option.defaultValue (Html.h1 [
                prop.style [ style.color.crimson ];
                prop.text (sprintf "Could not find sample app '%s'" sampleName)
            ])
        Html.div [
            sampleApp
            Highlight.highlight [
                prop.className "fsharp"
                prop.text(codeProps.value)
            ]
        ]
    else
        Highlight.highlight [
            prop.className "fsharp"
            prop.text(codeProps.value)
        ]

let renderMarkdown (path: string) (content: string) =
    Html.div [
        prop.className [ Bulma.Content; "scrollbar" ]
        prop.style [ 
            style.width (length.percent 100)
            style.padding (0,20)
        ]
        prop.children [
            if path.StartsWith "https://raw.githubusercontent.com" then
                Html.h2 [
                    Html.i [ prop.className [ FA.Fa; FA.FaGithub ] ]
                    Html.anchor [
                        prop.style [ style.marginLeft 10; style.color.lightGreen ]
                        prop.href (githubPath path)
                        prop.text "View on Github"
                    ]
                ]

            Markdown.markdown [
                markdown.source content
                markdown.escapeHtml false
                markdown.renderers [
                    markdown.renderers.code codeBlockRenderer
                ]
            ]
        ]
    ]

module MarkdownLoader =

    open Feliz.ElmishComponents

    type State =
        | Initial
        | Loading
        | Errored of string
        | LoadedMarkdown of content: string

    type Msg =
        | StartLoading of path: string list
        | Loaded of Result<string, int * string>

    let init (path: string list) = Initial, Cmd.ofMsg (StartLoading path)

    let resolvePath = function
    | [ one: string ] when one.StartsWith "http" -> one
    | segments -> String.concat "/" segments

    let update (msg: Msg) (state: State) =
        match msg with
        | StartLoading path ->
            let loadMarkdownAsync() = async {
                let! (statusCode, responseText) = Http.get (resolvePath path)
                if statusCode = 200
                then return Loaded (Ok responseText)
                else return Loaded (Error (statusCode, responseText))
            }

            Loading, Cmd.OfAsync.perform loadMarkdownAsync () id

        | Loaded (Ok content) ->
            State.LoadedMarkdown content, Cmd.none

        | Loaded (Error (status, _)) ->
            State.LoadedMarkdown (sprintf "Status %d: could not load markdown" status), Cmd.none

    let render path (state: State) dispatch =
        match state with
        | Initial -> Html.none
        | Loading -> centeredSpinner
        | LoadedMarkdown content -> renderMarkdown (resolvePath path) content
        | Errored error ->
            Html.h1 [
                prop.style [ style.color.crimson ]
                prop.text error
            ]

    let loadMarkdown' (path: string list) =
        React.elmishComponent("LoadMarkdown", init path, update, render path, key = resolvePath path)

let loadMarkdown (path: string list) = MarkdownLoader.loadMarkdown' path

// A collapsable nested menu for the sidebar
// keeps internal state on whether the items should be visible or not based on the collapsed state
let nestedMenuList' = FunctionComponent.Of((fun (state: State, name: string, basePath: string list, elems: (string list -> Fable.React.ReactElement) list, dispatch) ->
    let collapsed = 
        match state.CurrentTab with
        | [ ] -> false
        | _ -> 
            basePath 
            |> List.indexed 
            |> List.forall (fun (i, segment) -> 
                List.tryItem i state.CurrentTab 
                |> Option.map ((=) segment) 
                |> Option.defaultValue false) 

    Html.li [
        Html.anchor [
            prop.className Bulma.IsUnselectable
            prop.onClick <| fun _ -> 
                match collapsed with
                | true -> dispatch <| TabToggled (basePath |> List.rev |> List.tail |> List.rev)
                | false -> dispatch <| TabToggled basePath
            prop.children [
                Html.i [
                    prop.style [ style.marginRight 10 ]
                    prop.className [
                        FA.Fa
                        if not collapsed then FA.FaAngleDown else FA.FaAngleUp
                    ]
                ]
                Html.span name
            ]
        ]

        Html.ul [
            prop.className Bulma.MenuList
            prop.style [ 
                if not collapsed then yield! [ style.display.none ] 
            ]
            prop.children (elems |> List.map (fun f -> f basePath))
        ]
    ]), memoizeWith = memoEqualsButFunctions)

let sidebar (state: State) dispatch =
    let nestedMenuList (name: string) (basePath: string list) (items: (string list -> Fable.React.ReactElement) list) =
        nestedMenuList'(state, name, basePath, items, dispatch)

    let subNestedMenuList (name: string) (basePath: string list) (items: (string list -> Fable.React.ReactElement) list) (addedBasePath: string list) =
        nestedMenuList'(state, name, (addedBasePath @ basePath), items, dispatch)

    // top level label
    let menuLabel (content: string) =
        Html.p [
            prop.className [ Bulma.MenuLabel; Bulma.IsUnselectable ]
            prop.text content
        ]

    // top level menu
    let menuList (items: Fable.React.ReactElement list) =
        Html.ul [
            prop.className Bulma.MenuList
            prop.style [ style.width (length.percent 95) ]
            prop.children items
        ]

    let menuItem (name: string) (path: string list) =
        Html.li [
            Html.anchor [
                prop.className [
                    state.CurrentPath = path, Bulma.IsActive
                    state.CurrentPath = path, Bulma.HasBackgroundPrimary
                ]
                prop.text name
                prop.href (sprintf "#/%s" (String.concat "/" path))
            ]
        ]

    let nestedMenuItem (name: string) (extendedPath: string list) (basePath: string list) =
        let path = basePath @ extendedPath
        Html.li [
            Html.anchor [
                prop.className [
                    state.CurrentPath = path, Bulma.IsActive
                    state.CurrentPath = path, Bulma.HasBackgroundPrimary
                ]
                prop.text name
                prop.href (sprintf "#/%s" (String.concat "/" path))
            ]
        ]

    let allItems =
        Html.div [
            prop.className "scrollbar"
            prop.children [
                menuList [
                    menuItem "Overview" [ ]
                    menuItem "Installation" [ Urls.Pickers; Urls.Installation ]
                    menuItem "Release Notes" [ Urls.Pickers; Urls.ReleaseNotes ]
                    menuItem "Contributing" [ Urls.Pickers; Urls.Contributing ]
                    menuLabel "Examples"
                    nestedMenuList "Date Picker" [ Urls.Pickers; Urls.Examples; Urls.Date ] [
                        nestedMenuItem "Basic" [ Urls.Basic ]
                        nestedMenuItem "Keyboard Input" [ Urls.KeyboardInput ]
                        nestedMenuItem "Different Views" [ Urls.DifferentViews ]
                        nestedMenuItem "Inline Mode" [ Urls.InlineMode ]
                        nestedMenuItem "Static Mode" [ Urls.StaticMode ]
                        nestedMenuItem "Customization" [ Urls.Customization ]
                        nestedMenuItem "Dynamic Data" [ Urls.DynamicData ]
                    ]
                ]
            ]
        ]

    // the actual nav bar
    Html.aside [
        prop.className Bulma.Menu
        prop.style [
            style.width (length.perc 100)
        ]
        prop.children [ menuLabel "Feliz.Plotly"; allItems ]
    ]

let readme = sprintf "https://raw.githubusercontent.com/%s/%s/master/README.md"
let contributing = sprintf "https://raw.githubusercontent.com/Zaid-Ajaj/Feliz/master/public/Feliz/Contributing.md"

let examples (currentPath: string list) =
    match currentPath with
    | Urls.Date :: rest -> 
        match rest with
        | [ Urls.Basic ] -> [ "Basic.md" ]
        | [ Urls.KeyboardInput ] -> [ "KeyboardInput.md" ]
        | [ Urls.DifferentViews ] -> [ "DifferentViews.md" ]
        | [ Urls.InlineMode ] -> [ "InlineMode.md" ]
        | [ Urls.StaticMode ] -> [ "StaticMode.md" ]
        | [ Urls.Customization ] -> [ "Customization.md" ]
        | [ Urls.DynamicData ] -> [ "DynamicData.md" ]
        | _ -> []
        |> List.append [ Urls.Date ]
    | _ -> []

let content state dispatch =
    let tryTakePath (basePath: string list) (path: string list) =
        let num = path.Length
        if basePath.Length >= num then
            basePath |> List.take num = path
        else false

    match state.CurrentPath with
    | [ Urls.Pickers; Urls.Overview; ] -> lazyView loadMarkdown [ "Pickers"; "README.md" ]
    | [ Urls.Pickers; Urls.Installation ] -> lazyView loadMarkdown [ "Pickers"; "Installation.md" ]
    | [ Urls.Pickers; Urls.ReleaseNotes ] -> lazyView loadMarkdown [ "Pickers"; "RELEASE_NOTES.md" ]
    | [ Urls.Pickers; Urls.Contributing ] -> lazyView loadMarkdown [ contributing ]
    | _ when tryTakePath state.CurrentPath [ Urls.Pickers; Urls.Examples ] -> 
        match state.CurrentPath |> List.skip 1 with
        | datePath when tryTakePath datePath [ Urls.Examples ] -> datePath |> List.skip 1 |> examples
        | _ -> [ ]
        |> fun path ->
            if path |> List.isEmpty then Html.div [ for segment in state.CurrentPath -> Html.p segment ]
            else [ Urls.Pickers; Urls.Examples ] @ path |> (lazyView loadMarkdown)
    | _ -> lazyView loadMarkdown [ "Pickers"; "README.md" ]

let main state dispatch =
    Html.div [
        prop.className [ Bulma.Tile; Bulma.IsAncestor ]
        prop.children [
            Html.div [
                prop.className [ Bulma.Tile; Bulma.Is2 ]
                prop.children [ sidebar state dispatch ]
            ]

            Html.div [
                prop.className Bulma.Tile
                prop.style [ style.paddingTop 30 ]
                prop.children [ content state dispatch ]
            ]
        ]
    ]

let render (state: State) dispatch =
    let application =
        Html.div [
            prop.style [ 
                style.padding 30
            ]
            prop.children [ main state dispatch ]
        ]

    Router.router [
        Router.onUrlChanged (UrlChanged >> dispatch)
        Router.application application
    ]

Program.mkProgram init update render
|> Program.withReactSynchronous "root"
|> Program.withConsoleTrace
|> Program.run
