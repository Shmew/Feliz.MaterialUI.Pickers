[<RequireQualifiedAccess>]
module Samples.Date.Customization

open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let private useStyles : unit -> _ = Styles.makeStyles <| fun (theme: Theme) ->
    {| dayWrapper = Styles.create [ style.position.relative ]
       day = 
           Styles.create
             [ style.width 36
               style.height 36
               style.custom ("fontSize", theme.typography.caption.fontSize)
               style.margin (0, 2) ]
       customDayHighlight =
           Styles.create
             [ style.position.absolute
               style.top 0
               style.bottom 0
               style.left 2
               style.right 2
               style.border (1, borderStyle.solid, "#f50057")
               style.borderRadius (length.percent 50) ]
       nonCurrentMonthDay = Styles.create [ style.color theme.palette.text.disabled ]
       highlightNonCurrentMonthDay = Styles.create [ style.color "#676767" ]
       highlight =
           Styles.create
             [ style.backgroundColor "#3f51b5"
               style.color theme.palette.common.white ]
       firstHighlight = 
           Styles.create 
             [ style.custom ("extend", "highlight")
               style.custom ("borderTopLeftRadius", "50%")
               style.custom ("borderBottomLeftRadius", "50%") ]
       endHighlight = 
           Styles.create 
             [ style.custom ("extend", "highlight")
               style.custom ("borderTopRightRadius", "50%")
               style.custom ("borderBottomRightRadius", "50%") ] |}

module DateFns =
    open Fable.Core.JsInterop

    let startOfWeek d : DateTime = importDefault "date-fns/startOfWeek"
    let endOfWeek d : DateTime = importDefault "date-fns/endOfWeek"
    let isWithinInterval d interval : bool = importDefault "date-fns/isWithinInterval"
    let isSameDay d1 d2 : bool = importDefault "date-fns/isSameDay"
    let format d fmt : string = importDefault "date-fns/format"
    let isValid d : bool = importDefault "date-fns/isValid"

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)

    let c = useStyles()

    let handleWeekChange (date: DateTime) = date |> DateFns.startOfWeek |> setState

    let renderDay (day: DateTime) (selectedDate: DateTime) dayInCurrentMonth _ =
        let start' = selectedDate |> DateFns.startOfWeek
        let end' = selectedDate |> DateFns.endOfWeek

        let dayIsBetween = DateFns.isWithinInterval day (createObj !!["start",start'; "end",end' ])
        let isFirstDay = DateFns.isSameDay day start' 
        let isLastDay = DateFns.isSameDay day end'

        let wrapperClasses = 
            [ if dayIsBetween then c.nonCurrentMonthDay
              if isFirstDay then c.firstHighlight
              if isLastDay then c.endHighlight ]

        let dayClasses =
            [ if dayInCurrentMonth then c.nonCurrentMonthDay
              if dayInCurrentMonth && dayIsBetween then c.highlightNonCurrentMonthDay ]

        Html.div [
            prop.classes wrapperClasses
            
            prop.children [
                Mui.iconButton [
                    prop.classes dayClasses
                    prop.text (DateFns.format day "d")
                ]
            ]
        ]

    let labelFunc date invalidLabel =
        if DateFns.isValid date then
            date
            |> DateFns.startOfWeek
            |> fun d -> DateFns.format d "MMM do"
        else invalidLabel

    Mui.pickerUtilsProvider [
        pickerUtilsProvider.utils.dateFns

        prop.children [
            Mui.grid [
                grid.container true
                grid.direction.row
                grid.justify.spaceEvenly

                prop.children [
                    Mui.datePicker [
                        datePicker.label "Week picker"
                        datePicker.value state
                        datePicker.onChange handleWeekChange
                        datePicker.renderDay renderDay
                        datePicker.labelFunc labelFunc
                        datePicker.animateYearScrolling true
                    ]
                ]
            ]
        ]
    ])
