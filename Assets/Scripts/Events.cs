using System;
using core;
//sample of events class
//一个events类对应一个module
public class EventsLogin
{
    public static Defs.Function ShowLogin;
}

public class EventsPlayerData
{
    public static Defs.ReturnFunction<UInt64> GetUserId;
}

public class EventsChat
{
    public static Defs.Function<string /*msg*/> AddChat;
}

public class EventsSkill
{
    public static Defs.Function<int /*castId*/, int/* skillId*/> CastSkill;
}


public class EventsRank
{
    public static Defs.Function ShowRank;
    public static Defs.Function RefreshRank;
}

public class EventsLog
{
    public static Defs.Function<string /*msg*/, int /*logLevel*/> Log;
}

public class EventsInput
{
}

public class EventsPlayerState
{

}