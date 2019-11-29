[<RequireQualifiedAccess>]
module Samples.Additional.UseUtils

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let innerRender = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)
    let u = Hooks.useUtils()

    Mui.datePicker [
        datePicker.label "Date Picker"
        if u.getYear state = 2019 then datePicker.helperText "It's the current year!"
        datePicker.value state
        datePicker.onChange setState
    ])

let render () =
    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children (innerRender())
        ]
    ]
