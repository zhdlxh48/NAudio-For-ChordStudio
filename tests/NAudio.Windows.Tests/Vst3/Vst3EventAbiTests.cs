// FORK-EDIT: Regression guard for the SDK x64 event layout; does not load a plug-in.
using System;
using System.Runtime.InteropServices;
using NAudio.Vst3;
using NUnit.Framework;

namespace NAudio.Windows.Tests.Vst3;

[TestFixture]
public class Vst3EventAbiTests
{
    [Test]
    public void Event_MatchesSdkX64HeaderAndUnionSize()
    {
        Assert.That(IntPtr.Size, Is.EqualTo(8));
        Type eventType = typeof(Vst3Plugin).Assembly.GetType("NAudio.Vst3.Interop.Event", true)!;
        Assert.That(Marshal.SizeOf(eventType), Is.EqualTo(48));
        Assert.That(Marshal.OffsetOf(eventType, "Flags").ToInt32(), Is.EqualTo(16));
        Assert.That(Marshal.OffsetOf(eventType, "Type").ToInt32(), Is.EqualTo(18));
        Assert.That(Marshal.OffsetOf(eventType, "UnionData").ToInt32(), Is.EqualTo(24));
    }
}
