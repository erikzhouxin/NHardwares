using System;

namespace System.Data.NS7NET
{
	// Token: 0x02000004 RID: 4
	public enum ErrorCode
	{
		// Token: 0x04000008 RID: 8
		NoError,
		// Token: 0x04000009 RID: 9
		WrongCPU_Type,
		// Token: 0x0400000A RID: 10
		ConnectionError,
		// Token: 0x0400000B RID: 11
		IPAddressNotAvailable,
		// Token: 0x0400000C RID: 12
		WrongVarFormat = 10,
		// Token: 0x0400000D RID: 13
		WrongNumberReceivedBytes,
		// Token: 0x0400000E RID: 14
		SendData = 20,
		// Token: 0x0400000F RID: 15
		ReadData = 30,
		// Token: 0x04000010 RID: 16
		WriteData = 50
	}
}
