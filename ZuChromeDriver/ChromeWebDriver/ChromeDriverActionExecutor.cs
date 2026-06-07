// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Drawing;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.Interactions;
using Zu.Chrome;

namespace Zu.ChromeWebDriver
{
    internal class ChromeDriverActionExecutor : IActionExecutor
    {
        private ZuChromeDriver _ZuChromeDriver;
        private CancellationTokenSource _performActionsCancellationTokenSource;
        public ChromeDriverActionExecutor(ZuChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public Task<bool> IsActionExecutor(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public async Task PerformActions(IList<ActionSequence> actionSequenceList, CancellationToken cancellationToken = default)
        {
            _performActionsCancellationTokenSource = new CancellationTokenSource();
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(_performActionsCancellationTokenSource.Token, cancellationToken))
            {
                try
                {
                    var ct = linkedCts.Token;
                    ct.ThrowIfCancellationRequested();
                    foreach (var action in actionSequenceList)
                    {
                        ct.ThrowIfCancellationRequested();
                        cancellationToken.ThrowIfCancellationRequested();
                        foreach (var interaction in action.Interactions)
                        {
                            //await Task.Delay(100);
                            if (interaction is PauseInteraction)
                            {
                                await Task.Delay(((PauseInteraction)interaction).Duration, ct).ConfigureAwait(false);
                            }
                            else if (interaction is PointerInputDevice.PointerDownInteraction)
                            {
                                var pdi = (PointerInputDevice.PointerDownInteraction)interaction;
                                var pk = ((PointerInputDevice)interaction.SourceDevice).PointerKind;
                                if (pk == PointerKind.Mouse)
                                {
                                    if (pdi.Button == MouseButton.Left)
                                    {
                                        await _ZuChromeDriver.Mouse.MouseDown(ToWebPoint(_ZuChromeDriver.Session.MousePosition), ct).ConfigureAwait(false);
                                    }
                                    else if (pdi.Button == MouseButton.Right)
                                    {
                                        await _ZuChromeDriver.Mouse.ContextClick(ToWebPoint(_ZuChromeDriver.Session.MousePosition), ct).ConfigureAwait(false);
                                    }
                                }
                                else if (pk == PointerKind.Touch)
                                {
                                    if (pdi.Button == MouseButton.Left)
                                    {
                                        await _ZuChromeDriver.TouchScreen.Down(_ZuChromeDriver.Session.MousePosition.X, _ZuChromeDriver.Session.MousePosition.Y, ct).ConfigureAwait(false);
                                    }
                                    else if (pdi.Button == MouseButton.Right)
                                    {
                                        throw new NotSupportedException("Touch with MouseButton.Right");
                                    }
                                }
                                else if (pk == PointerKind.Pen)
                                {
                                    throw new NotImplementedException("PointerKind.Pen");
                                }
                            }
                            else if (interaction is PointerInputDevice.PointerUpInteraction)
                            {
                                var pui = (PointerInputDevice.PointerUpInteraction)interaction;
                                var pk = ((PointerInputDevice)interaction.SourceDevice).PointerKind;
                                if (pk == PointerKind.Mouse)
                                {
                                    if (pui.Button == MouseButton.Left)
                                    {
                                        await _ZuChromeDriver.Mouse.MouseUp(ToWebPoint(_ZuChromeDriver.Session.MousePosition), ct).ConfigureAwait(false);
                                    }
                                    else if (pui.Button == MouseButton.Right)
                                    {
                                        await _ZuChromeDriver.Mouse.ContextClick(ToWebPoint(_ZuChromeDriver.Session.MousePosition), ct).ConfigureAwait(false);
                                    }
                                }
                                else if (pk == PointerKind.Touch)
                                {
                                    if (pui.Button == MouseButton.Left)
                                    {
                                        var p = _ZuChromeDriver.Session.MousePosition;
                                        await _ZuChromeDriver.TouchScreen.Up(p.X, p.Y, ct).ConfigureAwait(false);
                                    }
                                    else if (pui.Button == MouseButton.Right)
                                    {
                                        throw new NotSupportedException("Touch with MouseButton.Right");
                                    }
                                }
                                else if (pk == PointerKind.Pen)
                                {
                                    throw new NotImplementedException("PointerKind.Pen");
                                }
                            }
                            else if (interaction is PointerInputDevice.PointerCancelInteraction)
                            {
                            }
                            else if (interaction is PointerInputDevice.PointerMoveInteraction)
                            {
                                var pmi = (PointerInputDevice.PointerMoveInteraction)interaction;
                                var pk = ((PointerInputDevice)interaction.SourceDevice).PointerKind;
                                if (pk == PointerKind.Mouse)
                                {
                                    if (pmi.Target != null)
                                    {
                                        if (pmi.X != 0 || pmi.Y != 0)
                                        {
                                            WebPoint location = await pmi.Target.Location().ConfigureAwait(false);
                                            location = location.Offset(pmi.X, pmi.Y);
                                            await _ZuChromeDriver.Mouse.MouseMove(location, ct).ConfigureAwait(false);
                                        }
                                        else
                                        {
                                            //WebPoint location = await ZuChromeDriver.ElementUtils.GetElementClickableLocation(pmi.Target.Id, ct);
                                            //if (location == null) 
                                            var location = await _ZuChromeDriver.Elements.GetElementLocation(pmi.Target.Id, ct).ConfigureAwait(false);
                                            await _ZuChromeDriver.Mouse.MouseMove(location, ct).ConfigureAwait(false);
                                        }
                                    }
                                    else
                                        await _ZuChromeDriver.Mouse.MouseMove(OffsetWebPoint(_ZuChromeDriver.Session.MousePosition, pmi.X, pmi.Y), ct).ConfigureAwait(false);
                                }
                                else if (pk == PointerKind.Touch)
                                {
                                    if (pmi.Target != null)
                                    {
                                        if (pmi.X != 0 || pmi.Y != 0)
                                        {
                                            WebPoint location = await pmi.Target.Location().ConfigureAwait(false);
                                            location = location.Offset(pmi.X, pmi.Y);
                                            await _ZuChromeDriver.TouchScreen.Move(location.X, location.Y, ct).ConfigureAwait(false);
                                        }
                                        else
                                        {
                                            //WebPoint location = await ZuChromeDriver.ElementUtils.GetElementClickableLocation(pmi.Target.Id);
                                            var location = await _ZuChromeDriver.Elements.GetElementLocation(pmi.Target.Id, ct).ConfigureAwait(false);
                                            if (location != null)
                                                await _ZuChromeDriver.TouchScreen.Move(location.X, location.Y, ct).ConfigureAwait(false);
                                        }
                                    }
                                    else
                                    {
                                        var newLoc = OffsetWebPoint(_ZuChromeDriver.Session.MousePosition, pmi.X, pmi.Y);
                                        await _ZuChromeDriver.TouchScreen.Move(newLoc.X, newLoc.Y, ct).ConfigureAwait(false);
                                    }
                                }
                                else if (pk == PointerKind.Pen)
                                {
                                    throw new NotImplementedException("PointerKind.Pen");
                                }
                            }
                            else if (interaction is KeyInputDevice.KeyDownInteraction)
                            {
                                var value = ((KeyInputDevice.KeyDownInteraction)interaction).GetValue();
                                await _ZuChromeDriver.Keyboard.PressKey(value, ct).ConfigureAwait(false);
                            }
                            else if (interaction is KeyInputDevice.KeyUpInteraction)
                            {
                                var value = ((KeyInputDevice.KeyUpInteraction)interaction).GetValue();
                                await _ZuChromeDriver.Keyboard.ReleaseKey(value, ct).ConfigureAwait(false);
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public Task ResetInputState(CancellationToken cancellationToken = default)
        {
            return CancelCurrentActions();
        }

        private Task CancelCurrentActions()
        {
            _performActionsCancellationTokenSource?.Cancel();
            return Task.CompletedTask;
        }

        private static WebPoint ToWebPoint(Point p) => new WebPoint(p.X, p.Y);

        private static WebPoint OffsetWebPoint(Point p, int offsetX, int offsetY) =>
            new WebPoint(p.X + offsetX, p.Y + offsetY);
    }
}