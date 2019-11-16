# Feliz.MaterialUI.Pickers - Time Picker

Taken from [material-ui-pickers - Time Picker](https://material-ui-pickers.dev/demo/timepicker)

```fsharp:pickers-time-seconds
[<RequireQualifiedAccess>]
module Samples.Time.Seconds

open Fable.Core.JsInterop
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
                Mui.timePicker [
                    timePicker.ampm false
                    timePicker.openTo.hours
                    timePicker.views [
                        timePicker.views.hours
                        timePicker.views.minutes
                        timePicker.views.seconds
                    ]
                    timePicker.format "HH:mm:ss"
                    timePicker.label "With seconds"
                    timePicker.value state
                    timePicker.onChange setState
                ]
                Mui.timePicker [
                    timePicker.ampm false
                    timePicker.openTo.minutes
                    timePicker.views [
                        timePicker.views.minutes
                        timePicker.views.seconds
                    ]
                    timePicker.format "mm:ss"
                    timePicker.label "Minutes and seconds"
                    timePicker.value state
                    timePicker.onChange setState
                ]
            ]
        ]
    ])
```