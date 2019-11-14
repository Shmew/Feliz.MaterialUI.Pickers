module App

open Elmish
open Elmish.React
open Fable.MaterialUI.MaterialDesignIcons
open Fable.React
open Fable.SimpleHttp
open Feliz
open Feliz.Markdown
open Feliz.MaterialUI
open Feliz.Router
open Fable.Core.JsInterop

type AppTheme =
    { PaletteType: PaletteType
      Primary: string
      Secondary: string
      PrimaryCT: string
      Error: string }

    static member Dark =
        { PaletteType = PaletteType.Dark
          Primary = "#03DAC6"
          PrimaryCT = "#FFF"
          Secondary = "#7700b3"
          Error = "#CF6679" }

    static member Light =
        { PaletteType = PaletteType.Light
          Primary = "#00D1B2"
          PrimaryCT = "#FFF"
          Secondary = "#6200EE"
          Error = "#B00020" }

module AppTheme =
    let private buildTheme (theme: AppTheme) = Styles.createMuiTheme(jsOptions<Theme> <| fun t ->
        t.palette <-
            jsOptions<Palette> (fun p ->
                p.``type`` <- theme.PaletteType
                p.primary <-
                    !^(jsOptions<PaletteIntention> (fun pi -> 
                        pi.main <- theme.Primary
                        pi.contrastText <- theme.PrimaryCT))
                p.secondary <-
                    !^(jsOptions<PaletteIntention> (fun pi -> pi.main <- theme.Secondary))
                p.error <-
                    !^(jsOptions<PaletteIntention> (fun pi -> pi.main <- theme.Error))))

    let getTheme b =
        if b then AppTheme.Dark
        else AppTheme.Light
        |> buildTheme

    let useStyles : unit -> _ = Styles.makeStyles <| fun (theme: Theme) ->
        let drawerWidth = 200

        {| appBar =
            Styles.create
                [ style.zIndex (theme.zIndex.drawer + 1)
                  style.cursor "default"
                  style.userSelect.none
                  style.display.grid ]
           containerCard =
               Styles.create 
                   [ style.padding (length.em 1) ]
           content =
               Styles.create
                   [ style.flexGrow 1
                     style.height.inheritFromParent
                     style.paddingTop (length.em 6)
                     style.paddingLeft (length.em 2)
                     style.paddingRight (length.em 2)
                     style.paddingBottom (length.em 1) ]
           drawer =
               Styles.create
                   [ style.zIndex theme.zIndex.drawer
                     style.width drawerWidth
                     style.flexShrink 0 ]
           drawerPaper = Styles.create [ style.width drawerWidth ]
           fullSizeCard =
               Styles.create
                   [ style.paddingTop (length.em 1)
                     style.paddingBottom (length.em 1)
                     style.paddingLeft (length.em 5)
                     style.paddingRight (length.em 5)
                     style.flexGrow 1 ]
           githubButton = Styles.create [ style.custom ("color", "inherit"); style.custom ("backgroundColor", "inherit") ]
           githubText = Styles.create [ style.textTransform.none; style.margin 0 ]
           root =
               Styles.create
                   [ style.display.flex
                     style.height.inheritFromParent
                     style.userSelect.none ]
           sampleApp = Styles.create [ style.paddingTop (length.em 2); style.paddingBottom (length.em 2) ]
           title = Styles.create [ style.width (length.percent 100) ]
           titleButton =
               Styles.create
                   [ style.padding 5
                     style.paddingRight 10
                     style.paddingLeft 10
                     style.color.white
                     style.borderRadius (length.percent 20) ]
           toolbar = Styles.create [ yield! theme.mixins.toolbarStyles ]
           unselectable = Styles.create [ style.userSelect.none ]|}

module Store =
    open Browser.WebStorage

    [<RequireQualifiedAccess>]
    type Field = DarkTheme

    type Msg = ToggleDarkTheme

    type Model = { DarkTheme: bool }

    let private getItem (field: Field) f def =
        let tryF value =
            try
                f value |> Some
            with _ -> None

        localStorage.getItem (string field)
        |> function
        | value when isNull value -> None
        | value -> Some value
        |> Option.bind tryF
        |> defaultArg
        <| def

    let private setItem (field: Field) (value: string) = localStorage.setItem (string field, value)

    let private asBool (s: string) =
        match s.ToLower() with
        | "true" -> true
        | _ -> false

    let init() = { DarkTheme = getItem Field.DarkTheme asBool true }

    let update (msg: Msg) (model: Model) =
        match msg with
        | ToggleDarkTheme ->
            let newB = model.DarkTheme |> not
            string newB |> setItem Field.DarkTheme
            { model with DarkTheme = newB }, Cmd.none

type Highlight =
    static member inline highlight (properties: IReactProperty list) =
        Interop.reactApi.createElement(importDefault "react-highlight", createObj !!properties)

type Model = 
    { CurrentPath : string list
      CurrentTab: string list
      Store: Store.Model }


let init () = 
    { CurrentPath = [ ]
      CurrentTab = [ ]
      Store = Store.init() }, Cmd.none

type Msg =
    | StoreMsg of Store.Msg
    | TabToggled of string list
    | UrlChanged of string list

let update msg model =
    match msg with
    | StoreMsg msg' ->
        let m, cmd = Store.update msg' model.Store
        { model with Store = m }, Cmd.map StoreMsg cmd
    | TabToggled tabs ->
        match tabs with
        | [ ] -> { model with CurrentTab = [ ] }, Cmd.none
        | _ -> { model with CurrentTab = tabs }, Cmd.none
    | UrlChanged segments -> 
        { model with CurrentPath = segments }, 
        match model.CurrentTab with
        | [ ] when segments.Length > 2 -> 
            segments
            |> TabToggled
            |> Cmd.ofMsg
        | _ -> Cmd.none

let centeredSpinner =
    Html.div [
        prop.style [
            style.textAlign.center
            style.marginLeft length.auto
            style.marginRight length.auto
            style.marginTop 50
        ]
        prop.children [
            Mui.circularProgress []
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

module MarkdownView =

    let private githubPath (rawPath: string) =
        let parts = rawPath.Split('/')
        if parts.Length > 5
        then sprintf "http://www.github.com/%s/%s" parts.[3] parts.[4]
        else rawPath

    /// Renders a code block from markdown using react-highlight.
    /// Injects sample React components when the code block has language of the format <language>:<sample-name>
    let private codeBlockRenderer' = React.functionComponent (fun (input: {| codeProps: Markdown.ICodeProperties |}) ->
        let c = AppTheme.useStyles()

        if input.codeProps.language <> null && input.codeProps.language.Contains ":" then
            let languageParts = input.codeProps.language.Split(':')
            let sampleName = languageParts.[1]
            let sampleApp =
                samples
                |> List.tryFind (fun (name, _) -> name = sampleName)
                |> Option.map snd
                |> Option.defaultValue (Html.h1 [
                    prop.style [ style.color.crimson ];
                    prop.text (sprintf "Could not find sample app '%s'" sampleName)
                ])
            Mui.grid [
                grid.direction.column
                grid.container true

                prop.children [
                    Html.div [
                        prop.className c.sampleApp
                        prop.children sampleApp
                    ]
                    Highlight.highlight [
                        prop.className "fsharp"
                        prop.text(input.codeProps.value)
                    ]
                ]
            ]
        else
            Highlight.highlight [
                prop.className "fsharp"
                prop.text(input.codeProps.value)
            ])

    let codeBlockRenderer codeProps = codeBlockRenderer' {| codeProps = codeProps |}

    let private renderMarkdown = React.functionComponent (fun (input: {|path: string; content: string |}) ->
        let c = AppTheme.useStyles()

        Mui.grid [
            grid.container true
            prop.className "scrollbar"

            prop.children [
                Mui.card [
                    prop.className c.fullSizeCard

                    prop.children [
                        if input.path.StartsWith "https://raw.githubusercontent.com" then
                            Mui.button [
                                button.size.small
                                button.variant.text
                                button.disableRipple true
                                button.disableFocusRipple true
                                button.disableTouchRipple true
                                button.href (githubPath input.path)
                                prop.custom ("target", "_blank")
                                prop.children [
                                    Mui.grid [
                                        grid.container true
                                        grid.direction.row
                                        grid.justify.spaceEvenly
                                        
                                        prop.children [
                                            Mui.avatar [ 
                                                prop.className c.githubButton
                                                prop.children [ githubCircleIcon [] ]
                                            ]
                                            Mui.typography [
                                                prop.className c.githubText
                                                typography.variant.button
                                                typography.align.right
                                                typography.variant.h4
                                                typography.color.primary
                                                prop.children [
                                                    Html.p [
                                                        prop.className c.githubText
                                                        prop.text "View on Github"
                                                    ]
                                                ]
                                            ]
                                        ]
                                    ]
                                ]
                            ]

                        Markdown.markdown [
                            markdown.source input.content
                            markdown.escapeHtml false
                            markdown.disallowedTypes [ nodeTypes.link ]
                            Interop.mkAttr "unwrapDisallowed" true
                            markdown.renderers [
                                markdown.renderers.code codeBlockRenderer
                            ]
                        ]
                    ]
                ]
            ]
        ])

    let render path content = renderMarkdown {| path = path; content = content |}

module MarkdownLoader =

    open Feliz.ElmishComponents

    type State =
        | Initial
        | Loading
        | Errored of string
        | LoadedMarkdown of content: string

    type Model = { State: State }

    type Msg =
        | StartLoading of path: string list
        | Loaded of Result<string, int * string>

    let init (path: string list) = 
        { State = Initial }, Cmd.ofMsg (StartLoading path)

    let resolvePath = function
    | [ one: string ] when one.StartsWith "http" -> one
    | segments -> String.concat "/" segments

    let update (msg: Msg) (model: Model) =
        match msg with
        | StartLoading path ->
            let loadMarkdownAsync() = async {
                let! (statusCode, responseText) = Http.get (resolvePath path)
                if statusCode = 200
                then return Loaded (Ok responseText)
                else return Loaded (Error (statusCode, responseText))
            }

            { model with State = Loading }, Cmd.OfAsync.perform loadMarkdownAsync () id

        | Loaded (Ok content) ->
            { model with State = State.LoadedMarkdown content}, Cmd.none

        | Loaded (Error (status, _)) ->
            { model with State = State.LoadedMarkdown (sprintf "Status %d: could not load markdown" status) }, Cmd.none

    let render path (model: Model) dispatch =
        match model.State with
        | Initial -> Html.none
        | Loading -> centeredSpinner
        | LoadedMarkdown content -> MarkdownView.render (resolvePath path) content
        | Errored error ->
            Html.h1 [
                prop.style [ style.color.crimson ]
                prop.text error
            ]

    let loadMarkdown' (path: string list) =
        React.elmishComponent("LoadMarkdown", init path, update, render path, key = resolvePath path)

let loadMarkdown (path: string list) = MarkdownLoader.loadMarkdown' path

let nestedMenuList' = FunctionComponent.Of((fun (model: Model, name: string, basePath: string list, elems: (string list -> Fable.React.ReactElement) list, dispatch) ->
    let c = AppTheme.useStyles()

    Mui.listItem [
        prop.className c.unselectable
        listItem.children [
            Mui.grid [
                grid.container true
                grid.direction.column

                prop.children [
                    Mui.listItemText name
                    Mui.divider []
                    yield! elems |> List.map (fun f -> f basePath)
                ]
            ]
        ]
    ]), memoizeWith = memoEqualsButFunctions)

let sidebar (model: Model) dispatch =
    let nestedMenuList (name: string) (basePath: string list) (items: (string list -> Fable.React.ReactElement) list) =
        nestedMenuList'(model, name, basePath, items, dispatch)

    let menuItem (name: string) (path: string list) =
        Mui.link [
            prop.href (sprintf "#/%s" (String.concat "/" path))
            link.underline.none
            typography.color.inherit'

            prop.children [
                Mui.listItem [
                    listItem.selected (model.CurrentPath = path)
                    listItem.button true
                    prop.href (path |> String.concat "/" |> (+) "#")
                    prop.text name
                ]
            ]
        ]

    let nestedMenuItem (name: string) (extendedPath: string list) (basePath: string list) =
        menuItem name (basePath @ extendedPath)

    Mui.list [
        menuItem "Overview" [ ]
        menuItem "Installation" [ Urls.Pickers; Urls.Installation ]
        menuItem "Release Notes" [ Urls.Pickers; Urls.ReleaseNotes ]
        menuItem "Contributing" [ Urls.Pickers; Urls.Contributing ]

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

let content model dispatch =
    let tryTakePath (basePath: string list) (path: string list) =
        let num = path.Length
        if basePath.Length >= num then
            basePath |> List.take num = path
        else false

    match model.CurrentPath with
    | [ Urls.Pickers; Urls.Overview; ] -> lazyView loadMarkdown [ "Pickers"; "README.md" ]
    | [ Urls.Pickers; Urls.Installation ] -> lazyView loadMarkdown [ "Pickers"; "Installation.md" ]
    | [ Urls.Pickers; Urls.ReleaseNotes ] -> lazyView loadMarkdown [ "Pickers"; "RELEASE_NOTES.md" ]
    | [ Urls.Pickers; Urls.Contributing ] -> lazyView loadMarkdown [ contributing ]
    | _ when tryTakePath model.CurrentPath [ Urls.Pickers; Urls.Examples ] -> 
        match model.CurrentPath |> List.skip 1 with
        | datePath when tryTakePath datePath [ Urls.Examples ] -> datePath |> List.skip 1 |> examples
        | _ -> [ ]
        |> fun path ->
            if path |> List.isEmpty then Html.div [ for segment in model.CurrentPath -> Html.p segment ]
            else [ Urls.Pickers; Urls.Examples ] @ path |> (lazyView loadMarkdown)
    | _ -> lazyView loadMarkdown [ "Pickers"; "README.md" ]

let render' = React.functionComponent (fun (input: {| model: Model; dispatch: Msg -> unit |}) ->
    let currentTheme = AppTheme.getTheme input.model.Store.DarkTheme
    let c = AppTheme.useStyles()

    Mui.themeProvider [ 
        themeProvider.theme currentTheme
        themeProvider.children [ 
            Html.div [ 
                prop.className c.root
                prop.children [ 
                    Mui.cssBaseline []
                    Mui.appBar [ 
                        prop.className c.appBar
                        appBar.color.secondary
                        appBar.position.fixed'
                        appBar.children [ 
                            Mui.toolbar [ 
                                toolbar.children [ 
                                    Mui.typography [
                                        prop.className c.title
                                        prop.text "Feliz.MaterialUI.Pickers"
                                        typography.align.left
                                    ]
                                    Mui.iconButton [ 
                                        prop.className c.titleButton
                                        iconButton.disableRipple true
                                        prop.onClick <| fun _ ->
                                            Store.ToggleDarkTheme
                                            |> StoreMsg
                                            |> input.dispatch
                                        prop.children [ 
                                            themeLightDarkIcon [] 
                                        ] 
                                    ]
                                    Mui.iconButton [
                                        prop.className c.titleButton
                                        prop.href "https://github.com/Shmew/Feliz.MaterialUI.Pickers"
                                        prop.custom ("target", "_blank")
                                        iconButton.disableRipple true

                                        prop.children [
                                            githubCircleIcon []
                                        ]
                                    ]
                                ] 
                            ] 
                        ] 
                    ]
                    Mui.card [
                        card.raised true
                        prop.children [
                            Mui.drawer [ 
                                prop.className c.drawer
                                drawer.variant.permanent
                                drawer.classes [ classes.drawer.paper c.drawerPaper ]
                                drawer.children [ 
                                    Html.div [ 
                                        prop.className c.toolbar 
                                    ]
                                    Mui.list [ 
                                        prop.className "scrollbar"
                                        list.component' "nav"
                                        list.children (sidebar input.model input.dispatch)
                                    ] 
                                ] 
                            ]
                        ]
                    ]
                    Html.main [ 
                        prop.className c.content
                        prop.children [ 
                            Mui.card [
                                card.raised true
                                prop.children (content input.model input.dispatch)
                            ]
                        ] 
                    ] 
                ] 
            ] 
        ] 
    ])

let render (model: Model) dispatch =
    Router.router [
        Router.onUrlChanged (UrlChanged >> dispatch)
        Router.application (render' {| model = model; dispatch = dispatch |})
    ]

Program.mkProgram init update render
|> Program.withReactSynchronous "root"
|> Program.withConsoleTrace
|> Program.run
