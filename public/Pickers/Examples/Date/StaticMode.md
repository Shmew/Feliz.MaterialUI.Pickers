# Feliz.MaterialUI.Pickers - Date Picker

Taken from [material-ui-pickers - Date Picker](https://material-ui-pickers.dev/demo/datepicker)

```fsharp:pickers-date-staticmode
[<RequireQualifiedAccess>]
module Samples.Date.StaticMode

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.datePicker [
                    datePicker.autoOk true
                    datePicker.variant.static'
                    datePicker.openTo.year
                    datePicker.value state
                    datePicker.onChange setState
                ]
                Mui.datePicker [
                    datePicker.autoOk true
                    datePicker.orientation.landscape
                    datePicker.variant.static'
                    datePicker.openTo.date
                    datePicker.value state
                    datePicker.onChange setState
                ]
            ]
        ]
    ])
```