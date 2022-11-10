namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_MEDIA_FILE_FORMAT_E
    {
        NETDEV_MEDIA_FILE_MP4 = 0,    /* MP4(+)  mp4 media file (Audio + Video) */
        NETDEV_MEDIA_FILE_TS = 1,    /* TS(+)   TS media file (Audio + Video) */
        NETDEV_MEDIA_FILE_MP4_ADD_TIME = 2,    /* MP4(+) ,  MP4 media file with time in file name (Audio + Video) */
        NETDEV_MEDIA_FILE_TS_ADD_TIME = 3,    /* TS(+) ,  TS media file with time in file name (Audio + Video) */
        NETDEV_MEDIA_FILE_AUDIO_TS = 4,    /* TS()   TS audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_MP4 = 5,    /* MP4()   MP4 audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_TS_ADD_TIME = 6,    /* TS(),  TS audio file with time in file name (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_MP4_ADD_TIME = 7,    /* MP4(),  MP4 audio file with time in file name (Only audio) */
        NETDEV_MEDIA_FILE_MP4_ADD_RCD_TIME = 8,    /* MP4 media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_TS_ADD_RCD_TIME = 9,    /* TS media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_MP4_ADD_RCD_TIME = 10,   /* MP4 audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_AUDIO_TS_ADD_RCD_TIME = 11,   /* TS audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_VIDEO_MP4_ADD_RCD_TIME = 12,   /* mp4 media file (Only video) */
        NETDEV_MEDIA_FILE_VIDEO_TS_ADD_RCD_TIME = 13,   /* ts media file (Only video) */

        NETDEV_MEDIA_FILE_AVI = 14,   /* AVI media file (Audio + Video) */
        NETDEV_MEDIA_FILE_AVI_ADD_TIME = 15,   /* AVI media file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_AVI = 16,   /* AVI audio file (Only audio) */
        NETDEV_MEDIA_FILE_AUDIO_AVI_ADD_TIME = 17,   /* AVI audio file with time in file name (Only audio)*/
        NETDEV_MEDIA_FILE_AVI_ADD_RCD_TIME = 18,   /* AVI audio file with start and end times in file name (Audio + Video)*/
        NETDEV_MEDIA_FILE_AUDIO_AVI_ADD_RCD_TIME = 19,   /* AVI audio file with start and end times in file name (Only audio)*/
        NETDEV_MEDIA_FILE_VIDEO_AVI_ADD_RCD_TIME = 20,   /* AVI media file (Only video) */

        NETDEV_MEDIA_FILE_INVALID
    }

}
