# Feliz.MaterialUI.Pickers - Date & Time Picker

Taken from [material-ui-pickers - Date & Time Picker](https://material-ui-pickers.dev/demo/datetime-picker)

```fsharp:pickers-datetime-inlinemode
[<RequireQualifiedAccess>]
module Samples.Date.Basic

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
                    Mui.datePicker [
                        datePicker.label "Basic Example"
                        datePicker.value state
                        datePicker.onChange setState
                        datePicker.animateYearScrolling true
                    ]
                    Mui.datePicker [
                        datePicker.autoOk true
                        datePicker.label "Clearable"
                        datePicker.disableFuture true
                        datePicker.value state
                        datePicker.onChange setState
                    ]
                    Mui.datePicker [
                        datePicker.openTo.year
                        datePicker.format "dd/MM/yyyy"
                        datePicker.label "Date of Birth"
                        datePicker.disableFuture true
                        datePicker.views [
                            datePicker.views.year
                            datePicker.views.month
                            datePicker.views.date
                        ]
                        datePicker.value state
                        datePicker.onChange setState
                    ]
                ]
            ]
        ]
    ])
```