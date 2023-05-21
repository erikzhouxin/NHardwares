using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQSoundDepend_6G
    {
        /// <summary>
        /// 1 1 语音队列中每个语音的 ID，从 0 开始
        /// </summary>
        public byte VoiceID;
        /// <summary>
        /// 
        /// </summary>
        public EQSound_6G stSound;
    }
}
