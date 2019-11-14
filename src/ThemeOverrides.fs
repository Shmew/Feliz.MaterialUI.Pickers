namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI

[<Erase>]
type overrides =
    static member inline MuiPickersDay (rules: IMuiPickersDayOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersDay", createObj !!rules)
    static member inline MuiPickerDTHeader (rules: IMuiPickerDTHeaderOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickerDTHeader", createObj !!rules)
    static member inline MuiPickerDTTabs (rules: IMuiPickerDTTabsOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickerDTTabs", createObj !!rules)
    static member inline MuiPickersCalendar (rules: IMuiPickersCalendarOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersCalendar", createObj !!rules)
    static member inline MuiPickersCalendarHeader (rules: IMuiPickersCalendarHeaderOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersCalendarHeader", createObj !!rules)
    static member inline MuiPickersSlideTransition (rules: IMuiPickersSlideTransitionOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersSlideTransition", createObj !!rules)
    static member inline MuiPickersYearSelectionStyles (rules: IMuiPickersYearSelectionStylesOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersYearSelectionStyles", createObj !!rules)
    static member inline MuiPickersYear (rules: IMuiPickersYearOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersYear", createObj !!rules)
    static member inline MuiPickersMonthSelection (rules: IMuiPickersMonthSelectionOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersMonthSelection", createObj !!rules)
    static member inline MuiPickersMonth (rules: IMuiPickersMonthOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersMonth", createObj !!rules)
    static member inline MuiPickersTimePickerToolbar (rules: IMuiPickersTimePickerToolbarOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersTimePickerToolbar", createObj !!rules)
    static member inline MuiPickersClock (rules: IMuiPickersClockOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersClock", createObj !!rules)
    static member inline MuiPickersClockNumber (rules: IMuiPickersClockNumberOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersClockNumber", createObj !!rules)
    static member inline MuiPickersClockPointer (rules: IMuiPickersClockPointerOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersClockPointer", createObj !!rules)
    static member inline MuiPickersModal (rules: IMuiPickersModalOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersModal", createObj !!rules)
    static member inline MuiPickersToolbar (rules: IMuiPickersToolbarOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersToolbar", createObj !!rules)
    static member inline MuiPickersToolbarButton (rules: IMuiPickersToolbarButtonOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersToolbarButton", createObj !!rules)
    static member inline MuiPickersDatePickerRoot (rules: IMuiPickersDatePickerRootOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickersDatePickerRoot", createObj !!rules)
    static member inline MuiPickerDTToolbar (rules: IMuiPickerDTToolbarOverrideRule list) : IOverrideStyleSheet = unbox ("MuiPickerDTToolbar", createObj !!rules)

module overrides =

    [<Erase>]
    type muiPickersDay =
        static member inline day (styles: IStyleAttribute list) : IMuiPickersDayOverrideRule = unbox ("day", createObj !!styles)
        static member inline hidden (styles: IStyleAttribute list) : IMuiPickersDayOverrideRule = unbox ("hidden", createObj !!styles)
        static member inline current (styles: IStyleAttribute list) : IMuiPickersDayOverrideRule = unbox ("current", createObj !!styles)
        static member inline daySelected (styles: IStyleAttribute list) : IMuiPickersDayOverrideRule = unbox ("daySelected", createObj !!styles)
        static member inline dayDisabled (styles: IStyleAttribute list) : IMuiPickersDayOverrideRule = unbox ("dayDisabled", createObj !!styles)

    [<Erase>]
    type muiPickerDTHeader =
        static member inline toolbar (styles: IStyleAttribute list) : IMuiPickerDTHeaderOverrideRule = unbox ("toolbar", createObj !!styles)
        static member inline separator (styles: IStyleAttribute list) : IMuiPickerDTHeaderOverrideRule = unbox ("separator", createObj !!styles)

    [<Erase>]
    type muiPickerDTTabs =
        static member inline tabs (styles: IStyleAttribute list) : IMuiPickerDTTabsOverrideRule = unbox ("tabs", createObj !!styles)

    [<Erase>]
    type muiPickersCalendar =
        static member inline transitionContainer (styles: IStyleAttribute list) : IMuiPickersCalendarOverrideRule = unbox ("transitionContainer", createObj !!styles)
        static member inline minHeight (styles: IStyleAttribute list) : IMuiPickersCalendarOverrideRule = unbox ("minHeight", createObj !!styles)
        static member inline marginTop (styles: IStyleAttribute list) : IMuiPickersCalendarOverrideRule = unbox ("marginTop", createObj !!styles)

    [<Erase>]
    type muiPickersCalendarHeader =
        static member inline switchHeader (styles: IStyleAttribute list) : IMuiPickersCalendarHeaderOverrideRule = unbox ("switchHeader", createObj !!styles)
        static member inline transitionContainer (styles: IStyleAttribute list) : IMuiPickersCalendarHeaderOverrideRule = unbox ("transitionContainer", createObj !!styles)
        static member inline iconButton (styles: IStyleAttribute list) : IMuiPickersCalendarHeaderOverrideRule = unbox ("iconButton", createObj !!styles)
        static member inline daysHeader (styles: IStyleAttribute list) : IMuiPickersCalendarHeaderOverrideRule = unbox ("daysHeader", createObj !!styles)
        static member inline dayLabel (styles: IStyleAttribute list) : IMuiPickersCalendarHeaderOverrideRule = unbox ("dayLabel", createObj !!styles)

    [<Erase>]
    type muiPickersSlideTransition =
        static member inline transitionContainer (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("transitionContainer", createObj !!styles)
        static member inline slideEnterLeft (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideEnter-left", createObj !!styles)
        static member inline slideEnterRight (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideEnter-right", createObj !!styles)
        static member inline slideEnterActive (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideEnterActive", createObj !!styles)
        static member inline slideExit (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideExit", createObj !!styles)
        static member inline slideExitActiveLeftLeft (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideExitActiveLeft-left", createObj !!styles)
        static member inline slideExitActiveLeftRight (styles: IStyleAttribute list) : IMuiPickersSlideTransitionOverrideRule = unbox ("slideExitActiveLeft-right", createObj !!styles)

    [<Erase>]
    type muiPickersYearSelectionStyles =
        static member inline container (styles: IStyleAttribute list) : IMuiPickersYearSelectionStylesOverrideRule = unbox ("container", createObj !!styles)

    [<Erase>]
    type muiPickersYear =
        static member inline root (styles: IStyleAttribute list) : IMuiPickersYearOverrideRule = unbox ("root", createObj !!styles)
        static member inline yearSelected (styles: IStyleAttribute list) : IMuiPickersYearOverrideRule = unbox ("yearSelected", createObj !!styles)
        static member inline yearDisabled (styles: IStyleAttribute list) : IMuiPickersYearOverrideRule = unbox ("yearDisabled", createObj !!styles)

    [<Erase>]
    type muiPickersMonthSelection =
        static member inline container (styles: IStyleAttribute list) : IMuiPickersMonthSelectionOverrideRule = unbox ("container", createObj !!styles)

    [<Erase>]
    type muiPickersMonth =
        static member inline root (styles: IStyleAttribute list) : IMuiPickersMonthOverrideRule = unbox ("root", createObj !!styles)
        static member inline monthSelected (styles: IStyleAttribute list) : IMuiPickersMonthOverrideRule = unbox ("monthSelected", createObj !!styles)
        static member inline monthDisabled (styles: IStyleAttribute list) : IMuiPickersMonthOverrideRule = unbox ("monthDisabled", createObj !!styles)

    [<Erase>]
    type muiPickersTimePickerToolbar =
        static member inline toolbarLandscape (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("toolbarLandscape", createObj !!styles)
        static member inline toolbarAmpmLeftPadding (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("toolbarAmpmLeftPadding", createObj !!styles)
        static member inline separator (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("separator", createObj !!styles)
        static member inline hourMinuteLabel (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("hourMinuteLabel", createObj !!styles)
        static member inline hourMinuteLabelAmpmLandscape (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("hourMinuteLabelAmpmLandscape", createObj !!styles)
        static member inline hourMinuteLabelReverse (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("hourMinuteLabelReverse", createObj !!styles)
        static member inline ampmSelection (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("ampmSelection", createObj !!styles)
        static member inline ampmLandscape (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("ampmLandscape", createObj !!styles)
        static member inline ampmSelectionWithSeconds (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("ampmSelectionWithSeconds", createObj !!styles)
        static member inline ampmLabel (styles: IStyleAttribute list) : IMuiPickersTimePickerToolbarOverrideRule = unbox ("ampmLabel", createObj !!styles)

    [<Erase>]
    type muiPickersClock =
        static member inline clock (styles: IStyleAttribute list) : IMuiPickersClockOverrideRule = unbox ("clock", createObj !!styles)
        static member inline squareMask (styles: IStyleAttribute list) : IMuiPickersClockOverrideRule = unbox ("squareMask", createObj !!styles)
        static member inline pin (styles: IStyleAttribute list) : IMuiPickersClockOverrideRule = unbox ("pin", createObj !!styles)

    [<Erase>]
    type muiPickersClockNumber =
        static member inline clockNumber (styles: IStyleAttribute list) : IMuiPickersClockNumberOverrideRule = unbox ("clockNumber", createObj !!styles)
        static member inline clockNumberSelected (styles: IStyleAttribute list) : IMuiPickersClockNumberOverrideRule = unbox ("clockNumberSelected", createObj !!styles)

    [<Erase>]
    type muiPickersClockPointer =
        static member inline pointer (styles: IStyleAttribute list) : IMuiPickersClockPointerOverrideRule = unbox ("pointer", createObj !!styles)
        static member inline animateTransform (styles: IStyleAttribute list) : IMuiPickersClockPointerOverrideRule = unbox ("animateTransform", createObj !!styles)
        static member inline thumb (styles: IStyleAttribute list) : IMuiPickersClockPointerOverrideRule = unbox ("thumb", createObj !!styles)
        static member inline noPoint (styles: IStyleAttribute list) : IMuiPickersClockPointerOverrideRule = unbox ("noPoint", createObj !!styles)

    [<Erase>]
    type muiPickersModal =
        static member inline dialogRoot (styles: IStyleAttribute list) : IMuiPickersModalOverrideRule = unbox ("dialogRoot", createObj !!styles)
        static member inline dialogRootWider (styles: IStyleAttribute list) : IMuiPickersModalOverrideRule = unbox ("dialogRootWider", createObj !!styles)
        static member inline dialog (styles: IStyleAttribute list) : IMuiPickersModalOverrideRule = unbox ("dialog", createObj !!styles)
        static member inline withAdditionalAction (styles: IStyleAttribute list) : IMuiPickersModalOverrideRule = unbox ("withAdditionalAction", createObj !!styles)

    [<Erase>]
    type muiPickersToolbar =
        static member inline toolbar (styles: IStyleAttribute list) : IMuiPickersToolbarOverrideRule = unbox ("toolbar", createObj !!styles)
        static member inline toolbarLandscape (styles: IStyleAttribute list) : IMuiPickersToolbarOverrideRule = unbox ("toolbarLandscape", createObj !!styles)

    [<Erase>]
    type muiPickersToolbarButton =
        static member inline toolbarBtn (styles: IStyleAttribute list) : IMuiPickersToolbarButtonOverrideRule = unbox ("toolbarBtn", createObj !!styles)

    [<Erase>]
    type muiPickersDatePickerRoot =
        static member inline toolbar (styles: IStyleAttribute list) : IMuiPickersDatePickerRootOverrideRule = unbox ("toolbar", createObj !!styles)
        static member inline toolbarLandscape (styles: IStyleAttribute list) : IMuiPickersDatePickerRootOverrideRule = unbox ("toolbarLandscape", createObj !!styles)
        static member inline dateLandscape (styles: IStyleAttribute list) : IMuiPickersDatePickerRootOverrideRule = unbox ("dateLandscape", createObj !!styles)

    [<Erase>]
    type muiPickerDTToolbar =
        static member inline toolbar (styles: IStyleAttribute list) : IMuiPickerDTToolbarOverrideRule = unbox ("toolbar", createObj !!styles)
        static member inline separator (styles: IStyleAttribute list) : IMuiPickerDTToolbarOverrideRule = unbox ("separator", createObj !!styles)