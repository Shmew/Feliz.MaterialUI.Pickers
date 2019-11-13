namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

type IMuiCalendarOverrideRule = interface end
type IMuiClockViewOverrideRule = interface end
type IMuiDatePickerOverrideRule = interface end
type IMuiDateTimePickerOverrideRule = interface end
type IMuiKeyboardDatePickerOverrideRule = interface end
type IMuiKeyboardDateTimePickerOverrideRule = interface end
type IMuiKeyboardTimePickerOverrideRule = interface end
type IMuiTimePickerOverrideRule = interface end
type IMuiTimePickerViewOverrideRule = interface end

[<Erase>]
type overrides =
    static member inline muiCalendar (rules: IMuiCalendarOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiClockView (rules: IMuiClockViewOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiDatePicker (rules: IMuiDatePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiDateTimePicker (rules: IMuiDateTimePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiKeyboardDatePicker (rules: IMuiKeyboardDatePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiKeyboardDateTimePicker (rules: IMuiKeyboardDateTimePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiKeyboardTimePicker (rules: IMuiKeyboardTimePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiTimePicker (rules: IMuiTimePickerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)
    static member inline muiTimePickerView (rules: IMuiTimePickerViewOverrideRule list) : IOverrideStyleSheet = unbox ("MuiAppBar", createObj !!rules)

module overrides =

    [<Erase>]
    type muiCalendar =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiClockView =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiDatePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiDateTimePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiKeyboardDatePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiKeyboardDateTimePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiKeyboardTimePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiTimePicker =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)

    [<Erase>]
    type muiTimePickerView =
        /// Styles applied to the root element.
        static member inline root(styles: IStyleAttribute list) : IMuiAppBarOverrideRule = unbox ("root", createObj !!styles)
