# Feliz.MaterialUI.Pickers - Theme Overrides

```fsharp:pickers-additional-themeoverrides
[<RequireQualifiedAccess>]
module Samples.Additional.Overrides

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(Some DateTime.Now)

    Mui.themeProvider [
        themeProvider.theme (fun existingTheme ->
            Styles.createMuiTheme([
                yield! existingTheme.asPropArray
                theme.overrides.muiPickersDatePickerRoot.toolbar [
                    style.backgroundColor color.red
                ]
            ])
        )
        themeProvider.children [
            Mui.pickerUtilsProvider [
                Mui.grid [
                    grid.container true
                    grid.direction.row
                    grid.justify.spaceEvenly

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
                            datePicker.clearable true
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
        ]
    ])
```