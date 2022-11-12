namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_VOD_PLAY_STATUS_E
    {
        /**   Play status */
        NETDEV_PLAY_STATUS_16_BACKWARD = 0,            /* 16  Backward at 16x speed */
        NETDEV_PLAY_STATUS_8_BACKWARD = 1,            /* 8  Backward at 8x speed */
        NETDEV_PLAY_STATUS_4_BACKWARD = 2,            /* 4  Backward at 4x speed */
        NETDEV_PLAY_STATUS_2_BACKWARD = 3,            /* 2  Backward at 2x speed */
        NETDEV_PLAY_STATUS_1_BACKWARD = 4,            /* Backward at normal speed */
        NETDEV_PLAY_STATUS_HALF_BACKWARD = 5,            /* 1/2  Backward at 1/2 speed */
        NETDEV_PLAY_STATUS_QUARTER_BACKWARD = 6,            /* 1/4  Backward at 1/4 speed */
        NETDEV_PLAY_STATUS_QUARTER_FORWARD = 7,            /* 1/4  Play at 1/4 speed */
        NETDEV_PLAY_STATUS_HALF_FORWARD = 8,            /* 1/2  Play at 1/2 speed */
        NETDEV_PLAY_STATUS_1_FORWARD = 9,            /* Forward at normal speed */
        NETDEV_PLAY_STATUS_2_FORWARD = 10,           /* 2  Forward at 2x speed */
        NETDEV_PLAY_STATUS_4_FORWARD = 11,           /* 4  Forward at 4x speed */
        NETDEV_PLAY_STATUS_8_FORWARD = 12,           /* 8  Forward at 8x speed */
        NETDEV_PLAY_STATUS_16_FORWARD = 13,           /* 16  Forward at 16x speed */
        NETDEV_PLAY_STATUS_2_FORWARD_IFRAME = 14,           /* 2(I) Forward at 2x speed(I frame) */
        NETDEV_PLAY_STATUS_4_FORWARD_IFRAME = 15,           /* 4(I) Forward at 4x speed(I frame) */
        NETDEV_PLAY_STATUS_8_FORWARD_IFRAME = 16,           /* 8(I) Forward at 8x speed(I frame) */
        NETDEV_PLAY_STATUS_16_FORWARD_IFRAME = 17,           /* 16(I) Forward at 16x speed(I frame) */
        NETDEV_PLAY_STATUS_2_BACKWARD_IFRAME = 18,           /* 2(I) Backward at 2x speed(I frame) */
        NETDEV_PLAY_STATUS_4_BACKWARD_IFRAME = 19,           /* 4(I) Backward at 4x speed(I frame) */
        NETDEV_PLAY_STATUS_8_BACKWARD_IFRAME = 20,           /* 8(I) Backward at 8x speed(I frame) */
        NETDEV_PLAY_STATUS_16_BACKWARD_IFRAME = 21,           /* 16(I) Backward at 16x speed(I frame) */
        NETDEV_PLAY_STATUS_INTELLIGENT_FORWARD = 22,           /* Intelligent forward */
        NETDEV_PLAY_STATUS_1_FRAME_FORWD = 23,           /* Forward at 1 frame speed */
        NETDEV_PLAY_STATUS_1_FRAME_BACK = 24,           /* Backward at 1 frame speed */
        NETDEV_PLAY_STATUS_40_FORWARD = 25,           /* Forward at 40x speed*/

        NETDEV_PLAY_STATUS_32_FORWARD_IFRAME = 26,           /* Forward at 32x speed(I frame)*/
        NETDEV_PLAY_STATUS_32_BACKWARD_IFRAME = 27,           /* Backward at 32x speed(I frame)*/
        NETDEV_PLAY_STATUS_64_FORWARD_IFRAME = 28,           /* Forward at 64x speed(I frame)*/
        NETDEV_PLAY_STATUS_64_BACKWARD_IFRAME = 29,           /* Backward at 64x speed(I frame)*/
        NETDEV_PLAY_STATUS_128_FORWARD_IFRAME = 30,           /* Forward at 128x speed(I frame)*/
        NETDEV_PLAY_STATUS_128_BACKWARD_IFRAME = 31,           /* Backward at 128x speed(I frame)*/
        NETDEV_PLAY_STATUS_256_FORWARD_IFRAME = 32,           /* Forward at 256x speed(I frame)*/
        NETDEV_PLAY_STATUS_256_BACKWARD_IFRAME = 33,           /* Backward at 256x speed(I frame)*/

        NETDEV_PLAY_STATUS_32_FORWARD = 34,           /* Forward at 32x speed */
        NETDEV_PLAY_STATUS_32_BACKWARD = 35,           /* Backward at 32x speed */

        NETDEV_PLAY_STATUS_INVALID
    }

}
