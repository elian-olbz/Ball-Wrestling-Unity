package com.unity3d.player;

import android.os.Build;

public final class j {
    static final boolean a = (Build.VERSION.SDK_INT >= 21);
    static final boolean b = (Build.VERSION.SDK_INT >= 23);
    static final boolean c;
    static final e d = (b ? new h() : null);

    static {
        boolean z = true;
        if (Build.VERSION.SDK_INT < 24) {
            z = false;
        }
        c = z;
    }
}
