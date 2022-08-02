#ifndef _RWLPNRAPI_INCLDED_
#define _RWLPNRAPI_INCLDED_

#define BUILD_LPNR_DLL

#if defined _WIN32 || defined _WIN64
#ifdef BUILD_LPNR_DLL					// to buid a DLL
#define DLLAPI		__declspec(dllexport)
#define CALLTYPE	__stdcall
#elif defined IMPORT_LPNR_DLL				// use imported call in DLL
#define DLLAPI		__declspec(dllimport)
#define CALLTYPE	__stdcall
#else // defined USE_LPNR_AS_BUILTIN			// stattically linked into your application
#define DLLAPI		
#define CALLTYPE
#endif
#else  // [linux]
#define TRUE		1
#define FALSE	0
#define INVALID_SOCKET	(~0)
#define SOCKET_ERROR    (-1)
#define DLLAPI
#define CALLTYPE
typedef int						BOOL;
typedef int						SOCKET;
typedef unsigned char BYTE;
typedef unsigned long	DWORD;
typedef void *				PVOID;
typedef void *				HANDLE;
typedef const char *		LPCTSTR;
typedef char *				LPSTR;
#define	IN
#define OUT
#endif

#define EVT_ONLINE			1		// 识别机连线
#define EVT_OFFLINE		2		// 识别机离线
#define EVT_FIRED			3		// 识别触发
#define EVT_DONE			4		// 识别结束，结果可用
#define EVT_LIVE				5		// 实时图像更新
#define EVT_VLDIN			6		// 有车进入虚拟线圈
#define EVT_VLDOUT		7		// 车辆离开虚拟线圈识别区
#define EVT_EXTDI			8		// DI 状态变化 （一体机的才有用，有扩展DI点）
#define EVT_SNAP			9		// 收到抓拍 图片（使用LPNR_TakeSnapFrame获取抓拍图片才会收到此消息)
#define EVT_ASYNRX		10		// 收到透传串口数据
#define EVT_PLATENUM	11		// 收到提前发送的车牌号码 （在各种图片和最后结果发送之前先发送，让上位机更早获取到）
#define EVT_VERINFO		12		// 连线以后，已经收到版本讯息
#define EVT_ACK				13		// DO和脉冲输出命令的ACK帧收到

#ifdef __cplusplus
extern "C" {
#endif

typedef void (*LPNR_callback)(void *, int );

// 建立和摄像机的TCP连接，启动工作线程。
DLLAPI HANDLE CALLTYPE LPNR_Init( const char *strIP );
// 关闭连接，结束工作线程
DLLAPI BOOL CALLTYPE LPNR_Terminate(HANDLE h);
// 设置回调函数 （for Windows, LPNR_SetWinMsg is recommended）
DLLAPI BOOL CALLTYPE LPNR_SetCallBack(HANDLE h, LPNR_callback mycbfxc );
#if defined _WIN32 || defined _WIN64
DLLAPI BOOL CALLTYPE LPNR_SetWinMsg( HANDLE h, HWND hwnd, int msgno);
#endif
// 询问摄像机是否online
DLLAPI BOOL CALLTYPE LPNR_IsOnline(HANDLE h);
// 获取预先发送的车牌号码（在收到EVT_PLATENUM之后获取）
DLLAPI BOOL CALLTYPE LPNR_GetPlateNumberAdvance(HANDLE h, char *buf);
// 获取车牌号码，计算机收到EVT_DONE后调用才可以获取最新识别的车牌号码。
DLLAPI BOOL CALLTYPE LPNR_GetPlateNumber(HANDLE h, char *buf);
DLLAPI BOOL CALLTYPE LPNR_GetPlateAttribute(HANDLE h, BYTE *attr);
/* LPNR_GetPlateAttribute: 获取车辆其他信息，同样需要在收到EVT_DONE后调用
 * plate attribute:
 * attr长度是8个字节。每个字节内容为：
 * 0： 可信度 （0~100）（reserved）
 * 1： 车头或是车尾的车牌（reserved，1：车头，0xff 车尾，0 未知）
 * 2：车身颜色码 （reserved）
 * 3：车速 （只有超速触发时，速度值才有意义）
 * 4：触发源 (0：图片返送，1：上位机触发，2：线圈触发，3：定时触发，4：虚拟线圈触发，5：超速触发)
 * 5：车牌颜色代码 (PLATE_COLOR_E)
 * 6:  车牌类型(PLATE_TYPE_E)
 * 7：保留
 */
// 获取live jpeg帧。收到EVT_LIVE事件后调用。buf内容是完整的一个JPEG格式的图片内容。buf大小必须大于等于LPNR_GetLiveFrameSize返回的值。
DLLAPI int CALLTYPE LPNR_GetLiveFrameSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetLiveFrame(HANDLE h, void *buf);
// 以下函数获取抓拍图片。一样在收到EVT_DONE后调用
// 获取车牌彩色图，buf内容就是完整的一个bmp格式的图片，大小必须大于等于LPNR_GetPlateColorImageSize返回的值
DLLAPI int CALLTYPE LPNR_GetPlateColorImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetPlateColorImage(HANDLE h, void *buf);
// 获取车牌二指图（binary image），buf内容就是完整的一个bmp格式的图片，大小必须大于等于LPNR_GetPlateBinaryImageSize返回的值
DLLAPI int CALLTYPE LPNR_GetPlateBinaryImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetPlateBinaryImage(HANDLE h, void *buf);
// 获取抓拍图片（用来分析车牌号码的图片），buf内容就是该图片jpeg格式的完整内容，大小必须大于等于LPNR_GetCapturedImageSize返回的值
// 摄像机必须没有禁止发送抓拍全图才会收到这个图片
DLLAPI int CALLTYPE LPNR_GetCapturedImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetCapturedImage(HANDLE h, void *buf);
// 获取抓拍图片的车头图（用来分析车牌号码的图片），buf内容就是该图片jpeg格式的完整内容，大小必须大于等于LPNR_GetHeadImageSize返回的值
// 摄像机必须使能发送车头图才会在分析完车牌后收到这个图片
DLLAPI int CALLTYPE LPNR_GetHeadImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetHeadImage(HANDLE h, void *buf);
// 获取抓拍图片4/9解像度的图（用来分析车牌号码的图片），buf内容就是该图片jpeg格式的完整内容，大小必须大于等于LPNR_GetMiddlemageSize返回的值
// 摄像机必须使能发送4/9解像度图才会在分析完车牌后收到这个图片
DLLAPI int CALLTYPE LPNR_GetMiddleImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetMiddleImage(HANDLE h, void *buf);
// 获取抓拍图片1/4解像度的图（用来分析车牌号码的图片），buf内容就是该图片jpeg格式的完整内容，大小必须大于等于LPNR_GetQuadImageSize返回的值
// 摄像机必须使能发送1/4解像度图才会在分析完车牌后收到这个图片
DLLAPI int CALLTYPE LPNR_GetQuadImageSize(HANDLE h);
DLLAPI int CALLTYPE LPNR_GetQuadImage(HANDLE h, void *buf);
// 同步摄像机时间，该函数下发计算机时间给摄像机，用来设置摄像机系统时间。
DLLAPI BOOL CALLTYPE LPNR_SyncTime(HANDLE h);
// 重新设置心跳帧计时，在上位机更改时间后需要调用这个函数，避免工作线程误以为长时间未收到心跳帧而关闭连接。
DLLAPI BOOL CALLTYPE LPNR_ResetHeartBeat(HANDLE h);
// 获取完所有数据后，释放保存的图片数据。可以不调用。工作线程在下次开始识别分析时，会自动释放。
DLLAPI BOOL CALLTYPE LPNR_ReleaseData(HANDLE h);
// 上位机触发一次识别分析，条件是摄像机现在是idle状态（没有正在分析车牌中）
// LPNR_SoftTriggerEx 多一个参数Id，这是一个序号，每次触发递增。计算机使用同一个Id号多次发送，只会触发一次。这是在网络不稳定，多次发送确保可以触发时使用。
DLLAPI BOOL CALLTYPE LPNR_SoftTrigger(HANDLE h);
DLLAPI BOOL CALLTYPE LPNR_SoftTriggerEx(HANDLE h, int Id);
// 检查摄像机工作线程状态是否在闲置（等待下次触发）
DLLAPI BOOL CALLTYPE LPNR_IsIdle(HANDLE h);
// 获取最后一次车牌分析的处理时间。elaped time是wall clock，processed time是CPU time. 单位是msec
DLLAPI BOOL CALLTYPE LPNR_GetTiming(HANDLE h, int *elaped, int *processed );
// 控制实时JPEG帧，nSizeCode取值范围 0~3
// 0 - 关闭实时帧发送
// 1 - 发送全解像度
// 2 - 发送1/4解像度
// 3 - 发送1/16解像度
// 注释：需要配合识别机软件版本 1.3.5.18 或以上的版本，和旧版本连接的话，nSIzeCode 0 一样是关闭，!=0 开启。解像度根据当前设置的参数发送。
// 每个客户端可以设置自己需要的解像度，不会互相影响。
// 1.3.5.18版本之上，帧率会快很多。尤其是1/4, 1/16，几乎可以跑到满帧率（25以上）
// 对于不需要live jpeg帧的application, 建议关闭live jpeg, 可以节省大量的网络带宽。每次收到EVT_ONLINE消息后，就调用
// LPNR_EnableLiveFrame(h,0)可以保证关闭live jpeg. 不可以在LPNR_Init后立刻调用，因为那时候TCP连接还没建立。
DLLAPI BOOL CALLTYPE LPNR_EnableLiveFrame(HANDLE h, int nSizeCode);
// 获取一个抓拍帧，但是不进行车牌分析。这个函数只是触发一次抓拍，图片要在收到EVT_SNAP消息（事件）后，调用LPNR_GetCapturedImage获取
// bFlashLight TRUE是抓拍时补光，FALSE是不要补光。
DLLAPI BOOL CALLTYPE LPNR_TakeSnapFrame(HANDLE h, BOOL bFlashLight);
// LPNR_Lock/LPNR_Unlock - 对图片数据和车牌数据加锁/解锁。避免在读取过程中被工作线程刷新内容。
// 有读取live jpeg frame时，需要用到这个函数，否则很有可能在读取的过程中，新的一个实时帧又刷新buffer，造成读到的内容错误。
// 其他图片可以不加锁，因为它们只有在有识别结果时才会被刷新。
DLLAPI BOOL CALLTYPE LPNR_Lock( HANDLE h );
DLLAPI BOOL CALLTYPE LPNR_Unlock(HANDLE h);
// helper function
// 获取摄像机IP，这是给一个application连接多个识别机时，当收到一个消息，要知道这个消息是由哪台识别机发送的时候，可以调用这个函数。
DLLAPI BOOL CALLTYPE LPNR_GetMachineIP(HANDLE h, LPSTR strIP);
// 获取摄像机label（name of camera configured）
DLLAPI LPCTSTR CALLTYPE LPNR_GetCameraLabel(HANDLE h);
// new functions to obtain version and model
DLLAPI BOOL CALLTYPE LPNR_GetModelAndSensor(HANDLE h, int *modelId, int *sensorId);
DLLAPI BOOL CALLTYPE LPNR_GetVersion(HANDLE h, DWORD *version, int *algver);
DLLAPI BOOL CALLTYPE LPNR_GetCapability(HANDLE h, DWORD *cap);

// control camera's lighting control output. 
// onoff - 1 ON, 0 OFF
// msec - if 'onoff'==1, this argument set 'msec' to turn on. if 'msec' is 0 means turn on until explicitly turned off.
DLLAPI BOOL CALLTYPE LPNR_LightCtrl(HANDLE h, int onoff, int msec);
// control camaera's IR-cut lens.  'onoff' 1 apply IR-cut filter, 0 turn off IR-cut filter
DLLAPI BOOL CALLTYPE LPNR_IRCut(HANDLE h, int onoff);

// query function (use UDP, 不需要先建立连接) - 这个函数是设计给一个服务器系统，下面有几百个摄像机使用的。不需要建立
// 和每台射线机的TCP连接，而是针对每台摄像机轮询。
// note: 'tout' is response timed out setting in msec 
DLLAPI BOOL CALLTYPE LPNR_QueryPlate( IN LPCTSTR strIP, OUT LPSTR strPlate, int tout );
#if defined _WIN32 || defined _WIN64
// 如果AP没有自己启动Winsock子系统，也没有调用LPNR_Init, 那需要使用这个函数启动Winsock后才可以调用前面的UDP查询命令。
DLLAPI BOOL CALLTYPE LPNR_WinsockStart( BOOL bStart );
#endif

// extended DI/DO functions
// get current ext. DI (dio_val[0]) and DO (dio_val[1]) value
DLLAPI BOOL CALLTYPE LPNR_GetExtDIO(HANDLE h, short dio_val[]);
DLLAPI BOOL CALLTYPE LPNR_SetExtDO(HANDLE h, int pin, int value);
// output 50% duty cycle pulse train with 'period' (msec). count is pulse count. if count==0 means forever until stop explicitly (period 0 means stop).
DLLAPI BOOL CALLTYPE LPNR_PulseOut(HANDLE h, int pin, int period, int count);		

// Video OSD (On Screen Display) overlay functions
// OSD 共有8个区域，识别机系统只实现6个。其中前面5个是静态设置，也就是会保存在配置文件里面，识别机重新上电不会丢失。最后一个是动态叠加，是提供给
// 应用程序随时叠加多行字符在视频中指定的位置。这个设置在程序重启后会丢失。
// 叠加区域:
// 1 - 时间标签 - 固定是叠加在视频右上角。
// 2 - 识别机标签（在识别机参数设置里面赋予的识别机名称，例如 "园区站E02" 固定叠加在视频的顶端置中位置。
// 3 - logo图片，这是德亚的logo，可以替换logo文件改变logo内容。文件在识别机内部 /home/logo.bmp. 图片大小必须合理。否则会占通太大范围。这个图片叠加位置在视频左上角。
// 4 - ROI 矩形 叠加当前识别区设置的外框矩形。
// 5 - 车牌识别字串 - 叠加当前识别结果，每次识别结果变化就会自动替换为新的字串。识别结果的显示位置、驻留时长和淡出效果可以设置。
// 6 - 用户叠加区 这个区域是开放给用户程序叠加自己的文字讯息。文字可以是多行，对齐可以选择左对齐、右对齐、居中对齐，字符颜色，透明度都可以设置。
//      为了简化接口，对于不常用的特殊显示效果（文字底色，底色不透明度，显示时间，是否淡出，是否闪烁显示，闪烁的占空比等）暂时不提供。这些设置可以
//	    在目前的接口里面是设置死的，文字无底色（无底色的文字摄像机会加描边)，显示时间为一直显示直到被清除，不闪烁，不淡出。
// 以下函数是针对OSD功能提供的控制接口：

// 设置视频OSD叠加的时间标签位置，bEnable为TRUE使能，FALSE禁能叠加; x, y为叠加位置（视频左上角为原点），给(0,0)使用默认值（右上角）
DLLAPI BOOL CALLTYPE LPNR_SetOSDTimeStamp(HANDLE h, BOOL bEnable, int x, int y);
// 使能/禁能视频叠加摄像机标签， 标签文字‘label’如果不是NULL，会同时设置识别机标签（即使bEnable是FALSE）
DLLAPI BOOL CALLTYPE LPNR_SetOSDLabel(HANDLE h, BOOL bEnable, const char *label);
// 使能/禁能LOGO图片的叠加
DLLAPI BOOL CALLTYPE LPNR_SetOSDLogo(HANDLE h, BOOL bEnable);
// 使能/禁能ROI矩形的叠加
DLLAPI BOOL CALLTYPE LPNR_SetOSDROI(HANDLE h, BOOL bEnable);
// 使能/禁能车牌识别结果的叠加
// 其中：'bEnable' 控制是否叠加识别的车牌。'loc'控制显示的位置，取值范围为[1..3] 分别代表左下角，中间下缘，右下角。'dwell'是叠加显示的驻留时长(单位sec).
//            dwell赋值0表示一直显示直到新的车牌识别结果替代。'bFadeOut' 是否加上淡出效果。只有dwell>0时，淡出效果才有效。淡出时间固定是2秒。所以整体显示
//            时间是 dwell + 2 秒。
//            其他更细致的控制，例如字体、字号、文字颜色、透明度等，用户需要使用LPNRTool设置，这里不开放接口。
DLLAPI BOOL CALLTYPE LPNR_SetOSDPlate(HANDLE h, BOOL bEnable, int loc, int dwell, BOOL bFadeOut);
// 关闭用户文字叠加
DLLAPI BOOL CALLTYPE LPNR_UserOSDOff(HANDLE h);
// 显示用户叠加文字
// 'x', 'y' 为叠加位置，单位是像素,左上角为(0,0). 如果'x'为 -1~-9时，代表叠加位置在九宫格的哪个区域，-1为左上，-2为中上，-3为右上...-9为右下。x<0时，y值无效。
// 'align为对齐方式，1是左对齐，2是居中对齐，3是右对齐
// 'fontsz' 是字体大小，取值范围24，32，40，48 （摄像机字库如果没有指定的字号，会取近似）
// 'text_color'是字体颜色的RGB值
// 'opacity'是叠加文字的不透明度百分比，取值范围[0~100]。
// 'text' 是要叠加的文字，可以是多行字，文字中的换行符号'\n'会被移除，后续文字显示在下一行。
DLLAPI BOOL CALLTYPE LPNR_UserOSDOn(HANDLE h, int x, int y, int align, int fontsz, int text_color, int opacity, const char *text);
// 选择码流和编码器 - 主码流和次码流是否用小解像度
// encoder - 0 H264, 1 H265
DLLAPI BOOL CALLTYPE LPNR_SetStream(HANDLE h, int encoder, BOOL bSmallMajor, BOOL bSmallMinor);
// 抓拍图片控制 
DLLAPI BOOL CALLTYPE LPNR_SetCaptureImage(HANDLE h, BOOL bDisFull, BOOL bEnMidlle, BOOL bEnSmall, BOOL bEnHead, BOOL bEnTiny);
// 通用获取图片接口
#define IMGID_PLATEBIN				0		// 车牌二值图
#define IMGID_PLATECOLOR		1		// 车牌彩色图
#define IMGID_CAPFULL				2		// 抓拍全图
#define IMGID_CAPMIDDLE			3		// 抓拍中图 (4/9解像度)
#define IMGID_CAPSMALL			4		// 抓拍小图 (1/4解像度)
#define IMGID_CAPTINY				5		// 抓拍微图 (1/16或是1/25, 看抓拍机程序)
#define IMGID_CAPHEAD				6		// 抓拍车头图
#define IMGID_BUTT						7
#define IMGID_CAPLARGEST		11		// 最大抓拍图（在所有抓拍图中最大的)
#define IMGID_CAPSMALLEST		12		// 最小抓拍图 (在锁头抓拍图种最小的)

DLLAPI int CALLTYPE LPNR_GetSelectedImageSize(HANDLE h, int imageId);
DLLAPI int CALLTYPE LPNR_GetSelectedImage(HANDLE h, int imageId, void *buf);
// 收到事件EVT_FIRED时，调用此接口获取触发源, 返回值为以下之一
#define	TRG_UPLOAD				0		// 返送图片分析
#define	TRG_HOSTTRIGGER		1 		// 上位机软触发
#define	TRG_LOOPTRIGGER		2 		// 抓拍线圈触发
#define	TRG_AUTOTRIG			3		// 定时自动触发
#define	TRG_VLOOPTRG			4 		// 虚拟线圈检测触发
#define TRG_OVRSPEED 			5		// 超速触发抓拍
DLLAPI int CALLTYPE LPNR_GetTriggerSource(HANDLE h);

// 透传串口 - 摄像机有带外置串口的，可以使用以下串口透传函数，发送数据给摄像机，由摄像机转发到串口。摄像机接收到的串口数据
//                  可以回送给计算机。这就相当于在串口设备（例如LED显示屏）和计算机之间搭建一条虚拟的串口。摄像机不理会传输的内容
//                  只负责数据的中转。
// 打开/关闭透传串口, speed是波特率, Speed=0 为关闭串口, >0 打开串口设置该波特率。只接受8bit data, 1-stop bit, no parity
DLLAPI BOOL CALLTYPE LPNR_COM_init(HANDLE h, int Speed);
// 使能串口输入的接收（默认是不使能的，识别机收到串口输入不会发送给没有使能的客户端。所有有使能的客户端都会收到同样的数据）
// 动态库收到串口数据后，会发送事件EVT_ASYNRX（Windows消息或是回调函数）
DLLAPI BOOL CALLTYPE LPNR_COM_aync(HANDLE h, BOOL bEnable);
// 发送串口数据
DLLAPI BOOL CALLTYPE LPNR_COM_send(HANDLE h, const char *data, int len);
// 收到的串口数据，动态库保存在内部1K的ring buffer里面，用户使用以下函数获取RX数据讯息
DLLAPI int CALLTYPE LPNR_COM_iqueue(HANDLE h);		// 获取接收到的串口字节数（尚未被取走）
// 复制动态库保存的串口RX数据，共size字节。保存的数据不会移除。
// 返回值: 实际复制的字节数，如果size > ring buffer内可读的字节数，返回值是实际复制的字节数(也就是ring buffer内可读字节数)。
// 如果size <= ring buffer 保存的字节数，返回值就是size.
DLLAPI int CALLTYPE LPNR_COM_peek(HANDLE h, char *RxData, int size);
// 类似上个函数，但是数据在读取后由ring buffer内移除。
DLLAPI int CALLTYPE LPNR_COM_read(HANDLE h, char *RxData, int size);
// 由ring buffer内移除前面'size'字节
DLLAPI int CALLTYPE LPNR_COM_remove(HANDLE h, int size);
// 清除动态库内保存的所有串口接收数据
DLLAPI BOOL CALLTYPE LPNR_COM_clear(HANDLE h);
// note:
// LPNR_COM_peek + LPNR_COM_remove = LPNR_COM_read

#ifdef __cplusplus
}
#endif

#endif

