[<RequireQualifiedAccess>]
module Samples.Additional.Components

open Feliz
open Feliz.MaterialUI
open Feliz.MaterialUI.Pickers
open System

let render = React.functionComponent(fun () ->
    let state,setState = React.useState(DateTime.Now)

    Mui.pickerUtilsProvider (
        Mui.grid [
            grid.container true
            grid.direction.row
            grid.justify.spaceEvenly

            prop.children [
                Html.div [
                    Mui.paper [
                        prop.style [ style.overflow.hidden ]
                        prop.children [
                            Mui.calendar [
                                calendar.date state
                                calendar.value state
                                calendar.onChange setState
                            ]
                        ]
                    ]
                    Mui.button [
                        button.fullWidth true
                        prop.onClick <| fun _ -> setState DateTime.Now
                        prop.text (sprintf "Clear date %O" state)
                    ]
                ]
                Mui.clockView [
                    clockView.type'.hours
                    clockView.date state
                    clockView.ampm false
                    clockView.onMinutesChange (fun _ -> ())
                    clockView.onSecondsChange (fun _ -> ())
                    clockView.onHourChange setState
                ]
            ]
        ]
    ))
