void gain_float(float x, float k, out float o) 
{
    float a = 0.5*pow(2.0*((x<0.5)?x:1.0-x), k);
    o = (x<0.5)?a:1.0-a;
}

void expStep_float( float x, float k, float n , out float o)
{
    o = exp( -k*pow(x,n) );
}