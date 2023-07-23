namespace System.Data.NMQTT
{
    public interface IMqttClientCredentialsProvider
    {
        string GetUserName(MqttClientOptions clientOptions);

        byte[] GetPassword(MqttClientOptions clientOptions);
    }
}