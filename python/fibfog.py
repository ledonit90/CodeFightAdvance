import sys

def generate_fib_steps(n):
    a, b = 1, 1
    yield 1
    while a + b <= n:
        yield a + b
        a, b = b, a + b

def solution(A):
    n = len(A) + 1

    ret = [sys.maxsize] * (n + 1)
    ret[0] = 0

    for i in range(1, n + 1):
        if (i < n and A[i - 1] == 1) or (i == n):
            ret[i] = min([ret[i - x] + 1 for x in generate_fib_steps(i)])

    return ret[-1] if ret[-1] < sys.maxsize else -1