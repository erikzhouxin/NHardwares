using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQSoundDepend_6G
    {
        public byte VoiceID;    // 1 1 语音队列中每个语音的 ID，从 0 开始
        public EQSound_6G stSound;
    }
}
