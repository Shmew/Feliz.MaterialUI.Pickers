namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type themeProps =
    static member inline muiCalendar (props: IReactProperty list) : IThemeProps = unbox ("MuiCalendar", createObj !!props)
    static member inline muiClockView (props: IReactProperty list) : IThemeProps = unbox ("MuiClockView", createObj !!props)
    static member inline muiDatePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiDatePicker", createObj !!props)
    static member inline muiDateTimePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiDateTimePicker", createObj !!props)
    static member inline muiKeyboardDatePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiKeyboardDatePicker", createObj !!props)
    static member inline muiKeyboardDateTimePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiKeyboardDateTimePicker", createObj !!props)
    static member inline muiKeyboardTimePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiKeyboardTimePicker", createObj !!props)
    static member inline muiTimePicker (props: IReactProperty list) : IThemeProps = unbox ("MuiTimePicker", createObj !!props)
    static member inline muiTimePickerView (props: IReactProperty list) : IThemeProps = unbox ("MuiTimePickerView", createObj !!props)
