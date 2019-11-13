# Feliz.MaterialUI.Pickers - Date Picker

Taken from [material-ui-pickers - Date Picker](https://material-ui-pickers.dev/demo/datepicker)

```fsharp:pickers-date-keyboardinput
[<RequireQualifiedAccess>]
module Samples.Date.KeyboardInput

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)

    Mui.pickerUtilsProvider [
        pickerUtilsProvider.utils.dateFns

        prop.children [
            Mui.grid [
                grid.container true
                grid.direction.row
                grid.justify.spaceBetween

                prop.children [
                    Mui.keyboardDatePicker [
                        keyboardDatePicker.clearable true
                        keyboardDatePicker.value state
                        keyboardDatePicker.placeholder "10/10/2018"
                        keyboardDatePicker.onChange (fun d _ -> setState d)
                        keyboardDatePicker.minDate DateTime.Now
                        keyboardDatePicker.format "MM/dd/yyyy"
                    ]
                    Mui.keyboardDatePicker [
                        keyboardDatePicker.value state
                        keyboardDatePicker.placeholder "2018/10/10"
                        keyboardDatePicker.onChange (fun d _ -> setState d)
                        keyboardDatePicker.format "yyyy/MM/dd"
                    ]
                ]
            ]
        ]
    ])
```