[<RequireQualifiedAccess>]
module Samples.Time.Basic

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
                Mui.timePicker [
                    timePicker.autoOk true
                    timePicker.label "12 hours"
                    timePicker.value state
                    timePicker.onChange setState
                ]
                Mui.timePicker [
                    timePicker.clearable true
                    timePicker.ampm false
                    timePicker.label "24 hours"
                    timePicker.value state
                    timePicker.onChange setState
                ]
                Mui.timePicker [
                    timePicker.showTodayButton true
                    timePicker.todayLabel "now"
                    timePicker.label "Step = 5"
                    timePicker.value state
                    timePicker.minutesStep 5
                    timePicker.onChange setState
                ]
            ]
        ]
    ])
