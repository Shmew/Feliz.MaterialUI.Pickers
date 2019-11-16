# Feliz.MaterialUI.Pickers - Date Picker

Taken from [material-ui-pickers - Date Picker](https://material-ui-pickers.dev/demo/datepicker)

```fsharp:pickers-date-differentviews
[<RequireQualifiedAccess>]
module Samples.Date.DifferentViews

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
                    datePicker.views datePicker.views.year
                    datePicker.label "Year only"
                    datePicker.value state
                    datePicker.onChange setState
                ]
                Mui.datePicker [
                    datePicker.views [
                        datePicker.views.year
                        datePicker.views.month
                    ]
                    datePicker.label "Year and Month"
                    datePicker.minDate (DateTime(2018, 03, 01))
                    datePicker.maxDate (DateTime(2018, 06, 01))
                    datePicker.value state
                    datePicker.onChange setState
                ]
                Mui.datePicker [
                    datePicker.variant.inline'
                    datePicker.openTo.year
                    datePicker.views [
                        datePicker.views.year
                        datePicker.views.month
                    ]
                    datePicker.label "Year and Month"
                    datePicker.helperText "Start from year selection"
                    datePicker.value state
                    datePicker.onChange setState
                ]
            ]
        ]
    ])
```