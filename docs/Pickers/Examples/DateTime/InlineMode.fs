[<RequireQualifiedAccess>]
module Samples.DateTime.InlineMode

open Fable.Core
open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(Some DateTime.Now)

    Mui.pickerUtilsProvider [
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Mui.dateTimePicker [
                    dateTimePicker.variant.inline'
                    dateTimePicker.label "Basic Example"
                    dateTimePicker.value state
                    dateTimePicker.onChange setState
                ]
                Mui.dateTimePicker [
                    dateTimePicker.variant.inline'
                    dateTimePicker.label "With keyboard"
                    dateTimePicker.ampm false
                    dateTimePicker.format "yyyy/MM/dd HH:mm"
                    dateTimePicker.disablePast true
                    dateTimePicker.value state
                    dateTimePicker.onChange setState
                    dateTimePicker.onError (fun _ (d: DateTime option) -> JS.console.log d)
                ]
            ]
        ]
    ])
