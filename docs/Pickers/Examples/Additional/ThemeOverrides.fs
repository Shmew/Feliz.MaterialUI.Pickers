﻿[<RequireQualifiedAccess>]
module Samples.Additional.Overrides

open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

module Hooks =
    let useTheme () : Theme = import "useTheme" "@material-ui/core/styles"

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)
    let oldTheme = Hooks.useTheme() 

    React.useEffect (( fun () ->
        oldTheme.addOverrides [
            overrides.muiPickersDatePickerRoot [
                overrides.muiPickersDatePickerRoot.toolbar [
                    style.backgroundColor color.red
                ]
            ] 
        ]
    ), [| oldTheme :> obj |])

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
    ])
