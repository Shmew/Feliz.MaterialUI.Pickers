# Feliz.MaterialUI.Pickers - Date & Time Picker

Taken from [material-ui-pickers - Date & Time Picker](https://material-ui-pickers.dev/demo/datetime-picker)

```fsharp:pickers-datetime-basic
[<RequireQualifiedAccess>]
module Samples.DateTime.Basic

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
                Mui.dateTimePicker [
                    dateTimePicker.label "DateTimePicker"
                    dateTimePicker.inputVariant.outlined
                    dateTimePicker.value state
                    dateTimePicker.onChange setState
                ]
                Mui.dateTimePicker [
                    dateTimePicker.label "24h clock"
                    dateTimePicker.autoOk true
                    dateTimePicker.ampm false
                    dateTimePicker.disableFuture true
                    dateTimePicker.value state
                    dateTimePicker.onChange setState
                        
                ]
                Mui.dateTimePicker [
                    dateTimePicker.label "With Today Button"
                    dateTimePicker.disablePast true
                    dateTimePicker.showTodayButton true
                    dateTimePicker.value state
                    dateTimePicker.onChange setState
                ]
            ]
        ]
    ])
```