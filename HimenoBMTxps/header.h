#pragma once

#define DllExport   __declspec( dllexport )

extern "C"
{
    DllExport int main();
    DllExport void initmt();
    DllExport float jacobi(int nn);
    DllExport double fflop(int mx, int my, int mz);
    DllExport double mflops(int nn, double cpu, double flop);
    DllExport double second();
}
