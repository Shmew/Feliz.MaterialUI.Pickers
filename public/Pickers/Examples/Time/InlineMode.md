# Feliz.MaterialUI.Pickers - Time Picker

Taken from [material-ui-pickers - Time Picker](https://material-ui-pickers.dev/demo/timepicker)

```fsharp:pickers-time-inlinemode
[<RequireQualifiedAccess>]
module Samples.Time.InlineMode

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(Some (DateTime.Parse "2018-01-01T00:00:00.000Z"))

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.timePicker [
                    timePicker.variant.inline'
                    timePicker.label "Inline mode"
                    timePicker.value state
                    timePicker.onChange setState
                ]
                Mui.keyboardTimePicker [
                    keyboardTimePicker.ampm false
                    keyboardTimePicker.variant.inline'
                    keyboardTimePicker.label "With keyboard"
                    keyboardTimePicker.value state
                    keyboardTimePicker.onChange (fun d _ -> setState d)
                ]
            ]
        ]
    ])
```