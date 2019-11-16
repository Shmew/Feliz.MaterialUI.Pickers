# Feliz.MaterialUI.Pickers - Date & Time Picker

Taken from [material-ui-pickers - Date & Time Picker](https://material-ui-pickers.dev/demo/datetime-picker)

```fsharp:pickers-datetime-customization
[<RequireQualifiedAccess>]
module Samples.DateTime.Customization

open Fable.Core
open Fable.MaterialUI.MaterialDesignIcons
open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let (clearedDate : DateTime option), handleClearedDateChange = React.useState(None)
    let selectedDate, handleDateChange = React.useState(DateTime.Parse "2019-01-01T18:54")

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.dateTimePicker [
                    dateTimePicker.autoOk true
                    dateTimePicker.disableFuture true
                    dateTimePicker.hideTabs true
                    dateTimePicker.ampm false
                    dateTimePicker.value selectedDate
                    dateTimePicker.onChange handleDateChange
                    dateTimePicker.allowKeyboardControl false
                    dateTimePicker.minDate <| DateTime(2018, 01, 01)
                    dateTimePicker.helperText "Hardcoded helper text"
                    dateTimePicker.leftArrowIcon <| alarmIcon []
                    dateTimePicker.leftArrowButtonProps [
                        prop.ariaLabel "Prev month"
                    ]
                    dateTimePicker.rightArrowIcon <| alarmSnoozeIcon []
                    dateTimePicker.rightArrowButtonProps [
                        prop.ariaLabel "Next month"
                    ]
                    dateTimePicker.InputProps [
                        input.endAdornment (
                            Mui.inputAdornment [
                                inputAdornment.position.end'
                                prop.children [
                                    alarmIcon []
                                ]
                            ]
                        )
                    ]
                ]
                Mui.keyboardDateTimePicker [
                    keyboardDateTimePicker.label "Keyboard with error handler"
                    keyboardDateTimePicker.minDate <| DateTime.Parse "2018-01-01T00:00"
                    keyboardDateTimePicker.format "yyyy/MM/dd hh:mm a"
                    keyboardDateTimePicker.value selectedDate
                    keyboardDateTimePicker.onChange (fun d _ -> d |> handleDateChange)
                    keyboardDateTimePicker.onError (fun _ d -> JS.console.log d)
                ]
                Mui.dateTimePicker [
                    dateTimePicker.clearable true
                    dateTimePicker.helperText "Clear Initial State"
                    dateTimePicker.value clearedDate
                    dateTimePicker.onChange (Some >> handleClearedDateChange)
                ]
            ]
        ]
    ])
```