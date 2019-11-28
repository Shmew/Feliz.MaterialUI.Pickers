namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type Mui =
    static member inline calendar props = createElement (import "Calendar" "@material-ui/pickers") props
    static member inline clockView props = createElement (import "ClockView" "@material-ui/pickers") props
    static member inline datePicker props = createElement (import "DatePicker" "@material-ui/pickers") props
    static member inline dateTimePicker props = createElement (import "DateTimePicker" "@material-ui/pickers") props
    static member inline keyboardDatePicker props = createElement (import "KeyboardDatePicker" "@material-ui/pickers") props
    static member inline keyboardDateTimePicker props = createElement (import "KeyboardDateTimePicker" "@material-ui/pickers") props
    static member inline keyboardTimePicker props = createElement (import "KeyboardTimePicker" "@material-ui/pickers") props
    static member inline timePicker props = createElement (import "TimePicker" "@material-ui/pickers") props
    static member inline timePickerView props = createElement (import "TimePickerView" "@material-ui/pickers") props
    static member inline pickerUtilsProvider (prop: IReactProperty) = 
        [ Interop.mkAttr "utils" (importDefault "@date-io/date-fns"); prop ] 
        |> (createElement (import "MuiPickersUtilsProvider" "@material-ui/pickers"))
    static member inline pickerUtilsProvider (props: IReactProperty list) = 
        [ Interop.mkAttr "utils" (importDefault "@date-io/date-fns"); yield! props ] 
        |> (createElement (import "MuiPickersUtilsProvider" "@material-ui/pickers"))
    static member inline pickerUtilsProvider (children: ReactElement) = 
        [ Interop.mkAttr "utils" (importDefault "@date-io/date-fns"); pickerUtilsProvider.children children ] 
        |> (createElement (import "MuiPickersUtilsProvider" "@material-ui/pickers"))
    static member inline pickerUtilsProvider (children: ReactElement list) = 
        [ Interop.mkAttr "utils" (importDefault "@date-io/date-fns"); pickerUtilsProvider.children children ] 
        |> (createElement (import "MuiPickersUtilsProvider" "@material-ui/pickers"))
