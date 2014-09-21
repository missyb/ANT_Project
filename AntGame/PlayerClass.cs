class Player
{
    string PlayerName;
    float kJ, TargetkJ, maxP;
    float[][] History = new float[3][];
    int N, wrap, Nr;

    public Player(string name, float tkj) // Create Player with name and target kJ
    {
        kJ = 0;
        PlayerName = name;
        TargetkJ = tkj;
        N = 0;
        wrap = 0;
        maxP = 0;
        History[0] = new float[3000];
        History[1] = new float[3000];
        History[2] = new float[3000];

        History[0][0] = 0;
        History[1][0] = 0;
        History[2][0] = 0;

    }
    public Player()
        : this("dummydumb", 500) //default player name and kJ
    {

    }

    public float CurrentkJ() // return current total kJ
    {
        return kJ;
    }
    public float CurrentTime() // return most recent recorded time
    {
        return History[0][N];
    }
    public float CurrentPower() // return most recent power
    {
        return History[1][N];
    }
    public float MaxPower() // return maximum power recorded
    {
        return maxP;
    }

    public float Target() // Return target kJ
    {
        return TargetkJ;
    }

    public string Name() // Return player's name
    {
        return PlayerName;
    }

    public void AddkJ(float dkj) // update total kJ directly (this will put 'kJ' out of syc with History[][]!)
    {
        kJ += dkj;
    }

    public void AddkJ(int power, int t) // Add to total kJ, and update history of time, power, and kJ
    {
        float J = 0;
        if (power > maxP) maxP = power;
        J = (float)power * (float)t / (float)2048;
        kJ += J / (float)1000;

        if (N >= History[0].Length)
        {
            wrap++;
            Nr = N;
            N = 0;
            History[0][0] = 0;
            History[1][0] = 0;
            History[2][0] = 0;
        }

        History[0][N + 1] = History[0][N + 1] + (float)t / (float)2048;
        History[1][N + 1] = power;
        History[2][N + 1] = kJ;
        N++;
        if (wrap == 0) Nr = N;
    }
    public void ResetHistory() // Start writing history back at index 0
    {
        N = 0;
        Nr = 0;
    }

    public float[][] GetHistory() // Return 2D array of history
    {
        return History;
    }
    public float[] GetHistory(int i) // Return time, power, and history at index value i
    {
        float[] temp = new float[3];
        if (i < Nr)
        {
            temp[0] = History[0][i];
            temp[1] = History[1][i];
            temp[2] = History[2][i];
        }
        else
        {
            temp[0] = 0;
            temp[1] = 0;
            temp[2] = 0;
        }



        return temp;
    }
    public float[] GetHistory(float t) // Attempt to return a linear interpolation for power and kJ at time t
    {
        float[] temp = new float[3];


        bool found = false;
        float pct = 0;

        temp[0] = 0;
        temp[1] = 0;
        temp[2] = 0;

        if (t >= 0 && t <= History[0][Nr])
        {
            int i = 0;
            while (found == false && i < Nr)
            {

                if (History[i][0] == t)
                {
                    found = true;
                    return History[i];

                }
                else if (History[i][0] > t)
                {
                    pct = (t - History[i - 1][0]) / (History[i][0] - History[i - 1][0]);
                    temp[0] = t;
                    temp[1] = History[i - 1][1] + pct * (History[i][0] - History[i - 1][0]);
                    temp[2] = History[i - 1][2] + pct * (History[i][0] - History[i - 1][0]);

                    found = true;

                    return temp;
                }

                i++;
            }
            return temp;
        }
        else return temp;

    }
    public float[] GetHistoryTimes() // return array of measurement times
    {
        return History[0];
    }
    public float[] GetHistoryPowers() // return array of power at each time
    {
        return History[1];
    }
    public float[] GetHistorykJ() // return array of total kJ at each time
    {
        return History[2];
    }
    public int HasWrapped() // Check how many times the history has wrapped back around to the beginning of the array
    {
        return wrap;
    }


}