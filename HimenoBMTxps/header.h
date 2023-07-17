#pragma once

extern "C"
{
    __declspec(dllexport) int main();
    __declspec(dllexport) void initmt();
    __declspec(dllexport) float jacobi(int nn);
    __declspec(dllexport) double fflop(int mx, int my, int mz);
    __declspec(dllexport) double mflops(int nn, double cpu, double flop);
    __declspec(dllexport) double second();
}
