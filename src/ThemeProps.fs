namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type themeProps =
    static member inline muiPickersDay (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersDay", createObj !!props)
    static member inline muiPickerDTHeader (props: IReactProperty list) : IThemeProps = unbox ("MuiPickerDTHeader", createObj !!props)
    static member inline muiPickerDTTabs (props: IReactProperty list) : IThemeProps = unbox ("MuiPickerDTTabs", createObj !!props)
    static member inline muiPickersCalendar (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersCalendar", createObj !!props)
    static member inline muiPickersCalendarHeader (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersCalendarHeader", createObj !!props)
    static member inline muiPickersSlideTransition (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersSlideTransition", createObj !!props)
    static member inline muiPickersYearSelectionStyles (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersYearSelectionStyles", createObj !!props)
    static member inline muiPickersYear (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersYear", createObj !!props)
    static member inline muiPickersMonthSelection (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersMonthSelection", createObj !!props)
    static member inline muiPickersMonth (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersMonth", createObj !!props)
    static member inline muiPickersTimePickerToolbar (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersTimePickerToolbar", createObj !!props)
    static member inline muiPickersClock (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersClock", createObj !!props)
    static member inline muiPickersClockNumber (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersClockNumber", createObj !!props)
    static member inline muiPickersClockPointer (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersClockPointer", createObj !!props)
    static member inline muiPickersModal (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersModal", createObj !!props)
    static member inline muiPickersToolbar (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersToolbar", createObj !!props)
    static member inline muiPickersToolbarButton (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersToolbarButton", createObj !!props)
    static member inline muiPickersDatePickerRoot (props: IReactProperty list) : IThemeProps = unbox ("MuiPickersDatePickerRoot", createObj !!props)
    static member inline muiPickerDTToolbar (props: IReactProperty list) : IThemeProps = unbox ("MuiPickerDTToolbar", createObj !!props)
