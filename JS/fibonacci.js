var yourself = {
    fibonacci : function(n) {
        if (n === 0||n === 1)  return n;
        var prev1 = 1;
        var prev2 = 0;
        for(var i=0; i < n-1; i++)
        {
            prev1 = prev1 + prev2;
            prev2 = prev1 - prev2;
        }
        return prev1;
    }
};