#pragma once

extern "C"
{
    __declspec(dllexport) int main(double* out1, double* out2, int* out3, float* out4, double* out5, double* out6, double* out7);
    __declspec(dllexport) void initmt();
    __declspec(dllexport) float jacobi(int nn);
    __declspec(dllexport) double fflop(int mx, int my, int mz);
    __declspec(dllexport) double mflops(int nn, double cpu, double flop);
    __declspec(dllexport) double second();
}
