# Feliz.MaterialUI.Pickers - Time Picker

Taken from [material-ui-pickers - Time Picker](https://material-ui-pickers.dev/demo/timepicker)

```fsharp:pickers-time-keyboardinput
[<RequireQualifiedAccess>]
module Samples.Time.KeyboardInput

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(Some DateTime.Now)

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.keyboardTimePicker [
                    keyboardTimePicker.label "Masked timepicker"
                    keyboardTimePicker.placeholder "08:00 AM"
                    keyboardTimePicker.mask "__:__ _M"
                    keyboardTimePicker.value state
                    keyboardTimePicker.onChange (fun d _ -> setState d)
                ]
            ]
        ]
    ])
```