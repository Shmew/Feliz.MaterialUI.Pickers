[<RequireQualifiedAccess>]
module Samples.Date.InlineMode

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
                        datePicker.variant.inline'
                        datePicker.label "Basic Example"
                        datePicker.value state
                        datePicker.onChange setState
                    ]
                    Mui.datePicker [
                        datePicker.disableToolbar true
                        datePicker.variant.inline'
                        datePicker.label "Only calendar"
                        datePicker.helperText "No year selection"
                        datePicker.value state
                        datePicker.onChange setState
                    ]
                    Mui.keyboardDatePicker [
                        keyboardDatePicker.autoOk true
                        keyboardDatePicker.format "MM/dd/yyyy"
                        keyboardDatePicker.label "With keyboard"
                        keyboardDatePicker.value state
                        keyboardDatePicker.InputAdornmentProps [
                            inputAdornment.position.start
                        ]
                        keyboardDatePicker.onChange (fun d _ -> setState d)
                    ]
                ]
            ]
        ]
    ])
