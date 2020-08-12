namespace AgarPlugin1
{
    static class Tags
    {
        // Use this tag when client connects to the Serverga. This tag is used to send unique ID of the client to the client.
        public const ushort connection = 0;

        // When client sends type to the  Serverga 
        public const ushort type = 1;

        // When Server sends collection info to the Client
        public const ushort collection = 2;

        // When Client sends juryNumber to the Server 
        public const ushort juryNumber = 3;

        //  When Client sends score to the Server 
        public const ushort score = 4;

        //  When Client sends OtherjuryNumber to the Server 
        public const ushort juryNumberOther = 5;

        // Not used yet
        public const ushort desktop = 6;

        // 
        public const ushort selectJuryNum = 7;

        // When playing game 
        public const ushort playGame = 8;

        // when setting time 
        public const ushort setTime = 9;

        // when pausing game 
        public const ushort pauseGame = 10;

        // when clearing all text data 
        public const ushort deleteGame = 11;

        // when jury is out 
        public const ushort juryIsOut = 12;

        // when round ends
        public const ushort round = 13;

        // when finishes all rounds
        public const ushort finishRound = 14;

    }
}
