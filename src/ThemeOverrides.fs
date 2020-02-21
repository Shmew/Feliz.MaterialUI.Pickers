namespace Feliz.MaterialUI.Pickers

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.MaterialUI
open System.ComponentModel

[<AutoOpen; EditorBrowsable(EditorBrowsableState.Never)>]
module themeOverrides =

    module theme =

        module overrides =

            [<Erase>]
            type muiPickersDay =
                static member inline day (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDay.day", createObj !!styles)
                static member inline hidden (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDay.hidden", createObj !!styles)
                static member inline current (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDay.current", createObj !!styles)
                static member inline daySelected (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDay.daySelected", createObj !!styles)
                static member inline dayDisabled (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDay.dayDisabled", createObj !!styles)

            [<Erase>]
            type muiPickerDTHeader =
                static member inline toolbar (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickerDTHeader.toolbar", createObj !!styles)
                static member inline separator (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickerDTHeader.separator", createObj !!styles)

            [<Erase>]
            type muiPickerDTTabs =
                static member inline tabs (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickerDTTabs.tabs", createObj !!styles)

            [<Erase>]
            type muiPickersCalendar =
                static member inline transitionContainer (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendar.transitionContainer", createObj !!styles)
                static member inline minHeight (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendar.minHeight", createObj !!styles)
                static member inline marginTop (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendar.marginTop", createObj !!styles)

            [<Erase>]
            type muiPickersCalendarHeader =
                static member inline switchHeader (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendarHeader.switchHeader", createObj !!styles)
                static member inline transitionContainer (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendarHeader.transitionContainer", createObj !!styles)
                static member inline iconButton (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendarHeader.iconButton", createObj !!styles)
                static member inline daysHeader (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendarHeader.daysHeader", createObj !!styles)
                static member inline dayLabel (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersCalendarHeader.dayLabel", createObj !!styles)

            [<Erase>]
            type muiPickersSlideTransition =
                static member inline transitionContainer (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.transitionContainer", createObj !!styles)
                static member inline slideEnterLeft (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideEnter-left", createObj !!styles)
                static member inline slideEnterRight (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideEnter-right", createObj !!styles)
                static member inline slideEnterActive (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideEnterActive", createObj !!styles)
                static member inline slideExit (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideExit", createObj !!styles)
                static member inline slideExitActiveLeftLeft (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideExitActiveLeft-left", createObj !!styles)
                static member inline slideExitActiveLeftRight (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersSlideTransition.slideExitActiveLeft-right", createObj !!styles)

            [<Erase>]
            type muiPickersYearSelectionStyles =
                static member inline container (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersYearSelectionStyles.container", createObj !!styles)

            [<Erase>]
            type muiPickersYear =
                static member inline root (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersYear.root", createObj !!styles)
                static member inline yearSelected (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersYear.yearSelected", createObj !!styles)
                static member inline yearDisabled (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersYear.yearDisabled", createObj !!styles)

            [<Erase>]
            type muiPickersMonthSelection =
                static member inline container (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersMonthSelection.container", createObj !!styles)

            [<Erase>]
            type muiPickersMonth =
                static member inline root (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersMonth.root", createObj !!styles)
                static member inline monthSelected (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersMonth.monthSelected", createObj !!styles)
                static member inline monthDisabled (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersMonth.monthDisabled", createObj !!styles)

            [<Erase>]
            type muiPickersTimePickerToolbar =
                static member inline toolbarLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.toolbarLandscape", createObj !!styles)
                static member inline toolbarAmpmLeftPadding (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.toolbarAmpmLeftPadding", createObj !!styles)
                static member inline separator (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.separator", createObj !!styles)
                static member inline hourMinuteLabel (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.hourMinuteLabel", createObj !!styles)
                static member inline hourMinuteLabelAmpmLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.hourMinuteLabelAmpmLandscape", createObj !!styles)
                static member inline hourMinuteLabelReverse (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.hourMinuteLabelReverse", createObj !!styles)
                static member inline ampmSelection (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.ampmSelection", createObj !!styles)
                static member inline ampmLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.ampmLandscape", createObj !!styles)
                static member inline ampmSelectionWithSeconds (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.ampmSelectionWithSeconds", createObj !!styles)
                static member inline ampmLabel (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersTimePickerToolbar.ampmLabel", createObj !!styles)

            [<Erase>]
            type muiPickersClock =
                static member inline clock (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClock.clock", createObj !!styles)
                static member inline squareMask (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClock.squareMask", createObj !!styles)
                static member inline pin (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClock.pin", createObj !!styles)

            [<Erase>]
            type muiPickersClockNumber =
                static member inline clockNumber (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockNumber.clockNumber", createObj !!styles)
                static member inline clockNumberSelected (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockNumber.clockNumberSelected", createObj !!styles)

            [<Erase>]
            type muiPickersClockPointer =
                static member inline pointer (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockPointer.pointer", createObj !!styles)
                static member inline animateTransform (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockPointer.animateTransform", createObj !!styles)
                static member inline thumb (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockPointer.thumb", createObj !!styles)
                static member inline noPoint (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersClockPointer.noPoint", createObj !!styles)

            [<Erase>]
            type muiPickersModal =
                static member inline dialogRoot (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersModal.dialogRoot", createObj !!styles)
                static member inline dialogRootWider (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersModal.dialogRootWider", createObj !!styles)
                static member inline dialog (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersModal.dialog", createObj !!styles)
                static member inline withAdditionalAction (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersModal.withAdditionalAction", createObj !!styles)

            [<Erase>]
            type muiPickersToolbar =
                static member inline toolbar (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersToolbar.toolbar", createObj !!styles)
                static member inline toolbarLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersToolbar.toolbarLandscape", createObj !!styles)

            [<Erase>]
            type muiPickersToolbarButton =
                static member inline toolbarBtn (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersToolbarButton.toolbarBtn", createObj !!styles)

            [<Erase>]
            type muiPickersDatePickerRoot =
                static member inline toolbar (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDatePickerRoot.toolbar", createObj !!styles)
                static member inline toolbarLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDatePickerRoot.toolbarLandscape", createObj !!styles)
                static member inline dateLandscape (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickersDatePickerRoot.dateLandscape", createObj !!styles)

            [<Erase>]
            type muiPickerDTToolbar =
                static member inline toolbar (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickerDTToolbar.toolbar", createObj !!styles)
                static member inline separator (styles: IStyleAttribute list) : IThemeProp = unbox ("overrides.MuiPickerDTToolbar.separator", createObj !!styles)
