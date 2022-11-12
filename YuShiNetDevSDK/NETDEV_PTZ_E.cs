namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_PTZ_E
    {
        NETDEV_PTZ_FOCUSNEAR_STOP = 0x0201,       /* Focus near stop */
        NETDEV_PTZ_FOCUSNEAR = 0x0202,       /* Focus near */
        NETDEV_PTZ_FOCUSFAR_STOP = 0x0203,       /* Focus far stop */
        NETDEV_PTZ_FOCUSFAR = 0x0204,       /* Focus far */

        NETDEV_PTZ_ZOOMTELE_STOP = 0x0301,       /* Zoom in stop */
        NETDEV_PTZ_ZOOMTELE = 0x0302,       /* Zoom in */
        NETDEV_PTZ_ZOOMWIDE_STOP = 0x0303,       /* Zoom out stop */
        NETDEV_PTZ_ZOOMWIDE = 0x0304,       /* Zoom out */
        NETDEV_PTZ_TILTUP = 0x0402,       /* Tilt up */
        NETDEV_PTZ_TILTDOWN = 0x0404,       /* Tilt down */
        NETDEV_PTZ_PANRIGHT = 0x0502,       /* Pan right */
        NETDEV_PTZ_PANLEFT = 0x0504,       /* Pan left */
        NETDEV_PTZ_LEFTUP = 0x0702,       /* Move up left */
        NETDEV_PTZ_LEFTDOWN = 0x0704,       /* Move down left */
        NETDEV_PTZ_RIGHTUP = 0x0802,       /* Move up right */
        NETDEV_PTZ_RIGHTDOWN = 0x0804,       /* Move down right */

        NETDEV_PTZ_ALLSTOP = 0x0901,       /* All-stop command word */
        NETDEV_PTZ_FOCUS_AND_IRIS_STOP = 0x0907,       /* Focus & Iris-stop command word */
        NETDEV_PTZ_MOVE_STOP = 0x0908,       /* move stop command word */
        NETDEV_PTZ_ZOOM_STOP = 0x0909,       /* zoom stop command word */

        NETDEV_PTZ_TRACKCRUISE = 0x1001,       /* Start route patrol*/
        NETDEV_PTZ_TRACKCRUISESTOP = 0x1002,       /* Stop route patrol*/
        NETDEV_PTZ_TRACKCRUISEREC = 0x1003,       /* Start recording route */
        NETDEV_PTZ_TRACKCRUISERECSTOP = 0x1004,       /* Stop recording route */
        NETDEV_PTZ_TRACKCRUISEADD = 0x1005,       /* Add patrol route */
        NETDEV_PTZ_TRACKCRUISEDEL = 0x1006,       /* Delete patrol route */

        NETDEV_PTZ_AREAZOOMIN = 0x1101,       /* Zoom in area */
        NETDEV_PTZ_AREAZOOMOUT = 0x1102,       /* Zoom out area */
        NETDEV_PTZ_AREAZOOM3D = 0x1103,       /* 3D positioning */

        NETDEV_PTZ_BRUSHON = 0x0A01,       /* Wiper on */
        NETDEV_PTZ_BRUSHOFF = 0x0A02,       /* Wiper off */

        NETDEV_PTZ_LIGHTON = 0x0B01,       /* Lamp on */
        NETDEV_PTZ_LIGHTOFF = 0x0B02,       /* Lamp off */

        NETDEV_PTZ_HEATON = 0x0C01,       /* Heater on */
        NETDEV_PTZ_HEATOFF = 0x0C02,       /* Heater off */

        NETDEV_PTZ_SNOWREMOINGON = 0x01301,       /* Snowremoval on */
        NETDEV_PTZ_SNOWREMOINGOFF = 0x01302,       /* Snowremoval off  */

        NETDEV_PTZ_INVALID

    }

}
