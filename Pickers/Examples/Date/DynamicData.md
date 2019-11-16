# Feliz.MaterialUI.Pickers - Date Picker

Taken from [material-ui-pickers - Date Picker](https://material-ui-pickers.dev/demo/datepicker)

```fsharp:pickers-date-dynamicdata
[<RequireQualifiedAccess>]
module Samples.Date.DynamicData

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let rng = Random()

let render = React.functionComponent(fun () ->
    let selectedDays, setSelectedDays = React.useState([ 1; 2; 15 ])
    let selectedDate, handleDateChange = React.useState(DateTime.Now)

    let handleMonthChange _ =
        promise {
            do! Promise.sleep (rng.Next(1000, 3000))
            [ 1 .. 3 ]
            |> List.map (fun _ -> rng.Next(1, 28))
            |> setSelectedDays
        }

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.datePicker [
                    datePicker.label "With server data"
                    datePicker.value selectedDate
                    datePicker.onChange handleDateChange
                    datePicker.onMonthChange handleMonthChange
                    datePicker.renderDay (fun day selectedDate isInCurrentMonth dayComponent ->
                        let isSelected = isInCurrentMonth && List.contains day.Day selectedDays

                        Mui.badge [
                            if isSelected then badge.badgeContent "🌚"
                            prop.children dayComponent
                        ]
                    )
                ]
            ]
        ]
    ])
```