﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalityValues{

    //Hard Coded Values for how the Personality Values of the Industry Leader's will affect their moods

    // happiness affected by openness
    public int HO1 = 0;
    public int HO2 = 0;
    public int HO3 = 1;
    public int HO4 = 2;
    public int HO5 = 3;
    // Happiness affected by Conscientiousness
    public int HC1 = 3;
    public int HC2 = 2;
    public int HC3 = 1;
    public int HC4 = 0;
    public int HC5 = -1;
    // Happiness affected by Extraversion
    public int HE1 = 1;
    public int HE2 = -1;
    public int HE3 = 1;
    public int HE4 = 1;
    public int HE5 = -2;
    // Happiness affected by Agreeableness
    public int HA1 = -2;
    public int HA2 = -1;
    public int HA3 = 1;
    public int HA4 = 1;
    public int HA5 = 2;
    // Happiness affected by Neuroticism
    public int HN1 = 0;
    public int HN2 = 1;
    public int HN3 = 2;
    public int HN4 = 3;
    public int HN5 = 4;

    // Angriness affected by openness
    public int AO1 = 0;
    public int AO2 = 0;
    public int AO3 = 0;
    public int AO4 = 0;
    public int AO5 = 0;
    // Angriness affected by Conscientiousness
    public int AC1 = 1;
    public int AC2 = 0;
    public int AC3 = -1;
    public int AC4 = -2;
    public int AC5 = -3;
    // Angriness affected by Extraversion
    public int AE1 = -1;
    public int AE2 = -1;
    public int AE3 = 0;
    public int AE4 = 1;
    public int AE5 = 2;
    // Angriness affected by Agreeableness
    public int AA1 = 2;
    public int AA2 = 1;
    public int AA3 = 1;
    public int AA4 = -1;
    public int AA5 = -2;
    // Angriness affected by Neuroticism
    public int AN1 = 0;
    public int AN2 = 1;
    public int AN3 = 2;
    public int AN4 = 3;
    public int AN5 = 4;

    //Greediness affected by Openness 
    public int GO1 = -1;
    public int GO2 = 0;
    public int GO3 = 0;
    public int GO4 = 0;
    public int GO5 = 1;
    // Greediness affected by Conscientiousness
    public int GC1 = 1;
    public int GC2 = -1;
    public int GC3 = 0;
    public int GC4 = -1;
    public int GC5 = 1;
    // Greediness affected by Extraversion
    public int GE1 = 1;
    public int GE2 = 0;
    public int GE3 = 0;
    public int GE4 = 0;
    public int GE5 = 1;
    // Greediness affected by Agreeableness
    public int GA1 = 3;
    public int GA2 = 2;
    public int GA3 = 1;
    public int GA4 = -1;
    public int GA5 = -2;
    // Greediness affected by Neuroticism 
    public int GN1 = 0;
    public int GN2 = 0;
    public int GN3 = 1;
    public int GN4 = 2;
    public int GN5 = 3;

    // Fearfulness affected by Openness
    public int FO1 = 2;
    public int FO2 = 1;
    public int FO3 = 0;
    public int FO4 = -1;
    public int FO5 = -2;
    // Fearfulness affected by Conscientiousness
    public int FC1 = -1;
    public int FC2 = 0;
    public int FC3 = 0;
    public int FC4 = 0;
    public int FC5 = 1;
    // Fearfulness affected by Extraversion 
    public int FE1 = -1;
    public int FE2 = 0;
    public int FE3 = 0;
    public int FE4 = -1;
    public int FE5 = -2;
    // Fearfulness affected by Agreeableness
    public int FA1 = -3;
    public int FA2 = -2;
    public int FA3 = -1;
    public int FA4 = 1;
    public int FA5 = 2;
    // Fearfulness affected by Neuroticism
    public int FN1 = 0;
    public int FN2 = 1;
    public int FN3 = 2;
    public int FN4 = 3;
    public int FN5 = 4;

    // Sadness affected by Openness
    public int SO1 = 0;
    public int SO2 = 0;
    public int SO3 = 0;
    public int SO4 = 0;
    public int SO5 = 0;
    // Sadness affected by Conscientiousness
    public int SC1 = 2;
    public int SC2 = 1;
    public int SC3 = 0;
    public int SC4 = -1;
    public int SC5 = -2;
    // Sadness affected by Extraversion
    public int SE1 = 0;
    public int SE2 = 0;
    public int SE3 = 0;
    public int SE4 = 0;
    public int SE5 = 0;
    // Sadness affected by Agreeableness 
    public int SA1 = 0;
    public int SA2 = 0;
    public int SA3 = 0;
    public int SA4 = 1;
    public int SA5 = 1;
    // Sadness affected by Neuroticism
    public int SN1 = 0;
    public int SN2 = 1;
    public int SN3 = 2;
    public int SN4 = 3;
    public int SN5 = 4;

    // Inspiration affected by Openness
    public int IO1 = -2;
    public int IO2 = -1;
    public int IO3 = 0;
    public int IO4 = 1;
    public int IO5 = 2;
    // Inspiration affected by Conscientiousness
    public int IC1 = -2;
    public int IC2 = -1;
    public int IC3 = 1;
    public int IC4 = 2;
    public int IC5 = 3;
    // Inspiration affected by Extraversion 
    public int IE1 = 1;
    public int IE2 = 0;
    public int IE3 = -1;
    public int IE4 = 0;
    public int IE5 = 1;
    // Inspiration affected by Agreeableness
    public int IA1 = 1;
    public int IA2 = 2;
    public int IA3 = 1;
    public int IA4 = -1;
    public int IA5 = -2;
    // Inspiration affected by Neuroticism
    public int IN1 = 0;
    public int IN2 = 0;
    public int IN3 = 1;
    public int IN4 = 2;
    public int IN5 = 3;

    // Boredom affected by Openness
    public int BO1 = -2;
    public int BO2 = -1;
    public int BO3 = 0;
    public int BO4 = 1;
    public int BO5 = 2;
    // Boredom affected by Conscientiousness
    public int BC1 = -1;
    public int BC2 = 0;
    public int BC3 = 0;
    public int BC4 = 0;
    public int BC5 = 1;
    // Boredom affected by Extraversion
    public int BE1 = -2;
    public int BE2 = -1;
    public int BE3 = 0;
    public int BE4 = 1;
    public int BE5 = 2;
    // Boredom affected by Agreeableness
    public int BA1 = 1;
    public int BA2 = 0;
    public int BA3 = 0;
    public int BA4 = 0;
    public int BA5 = 1;
    // Boredom affected by Neuroticism
    public int BN1 = 0;
    public int BN2 = 1;
    public int BN3 = 2;
    public int BN4 = 3;
    public int BN5 = 4;

}
