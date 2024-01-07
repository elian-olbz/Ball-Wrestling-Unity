package com.unity3d.player;

import android.content.Context;
import com.unity3d.player.a;

public class AudioVolumeHandler implements a.b {
    private a a;

    AudioVolumeHandler(Context context) {
        this.a = new a(context);
        this.a.a(this);
    }

    public final void a() {
        this.a.a();
        this.a = null;
    }

    public final native void onAudioVolumeChanged(int i);
}
