# Feliz.MaterialUI.Pickers - Time Picker

Taken from [material-ui-pickers - Time Picker](https://material-ui-pickers.dev/demo/timepicker)

```fsharp:pickers-time-staticmode
[<RequireQualifiedAccess>]
module Samples.Time.StaticMode

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
                Mui.timePicker [
                    timePicker.autoOk true
                    timePicker.variant.static'
                    timePicker.openTo.hours
                    timePicker.value state
                    timePicker.onChange setState
                ]
                Mui.timePicker [
                    timePicker.autoOk true
                    timePicker.ampm false
                    timePicker.variant.static'
                    timePicker.orientation.landscape
                    timePicker.openTo.minutes
                    timePicker.value state
                    timePicker.onChange setState
                ]
            ]
        ]
    ])
```