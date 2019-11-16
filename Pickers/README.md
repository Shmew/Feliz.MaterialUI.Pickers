# Feliz.MaterialUI.Pickers (alpha) [![Nuget](https://img.shields.io/nuget/v/Feliz.MaterialUI.Pickers.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.MaterialUI.Pickers)

Fable bindings for [material-ui-pickers](https://github.com/mui-org/material-ui-pickers) with [Feliz](https://github.com/Zaid-Ajaj/Feliz) style api for use within MaterialUI.

Here is a quick look:

```fs
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

Feliz.MaterialUI.Pickers has documentation at [Feliz.MaterialUI.Pickers](https://shmew.github.io/Feliz.MaterialUI.Pickers/) with live examples along side code samples.
