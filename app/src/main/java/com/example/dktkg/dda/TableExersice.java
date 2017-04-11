package com.example.dktkg.dda;


import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import com.google.android.youtube.player.YouTubeApiServiceUtil;
import com.google.android.youtube.player.YouTubeBaseActivity;
import com.google.android.youtube.player.YouTubeInitializationResult;
import com.google.android.youtube.player.YouTubePlayer;
import com.google.android.youtube.player.YouTubePlayer.Provider;
import com.google.android.youtube.player.YouTubePlayerView;

/**
 * Created by dktkg on 2017-03-23.
 */

public class TableExersice extends YouTubeBaseActivity implements
        YouTubePlayer.OnInitializedListener{
    private static final int RECOVERY_DIALOG_REQUEST = 1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tablethree);

        Log.d("youtube Test",
                "사용가능여부:"+YouTubeApiServiceUtil.isYouTubeApiServiceAvailable(this)); //SUCCSESS


        //YouTubePlayer를 초기화
        //public void initialize (String developerKey,
        //                        YouTubePlayer.OnInitializedListener onInitializedListener)

        //YouTubePlayerView youTubeView = (YouTubePlayerView) findViewById(R.id.youtube_view);
        //youTubeView.initialize(DeveloperKey.DEVELOPER_KEY, this);

        getYouTubePlayerProvider().initialize(DeveloperKey.DEVELOPER_KEY,this);

    }

    /**
     * 플레이어가 초기화될 때 호출됩니다.
     * 매개변수
     *
     * provider YouTubePlayer를 초기화화는 데 사용된 제공자입니다.
     * player 제공자에서 동영상 재생을 제어하는 데 사용할 수 있는 YouTubePlayer입니다
     * wasRestored
     *    YouTubePlayerView 또는 YouTubePlayerFragment가 상태를 복원하는 과정의 일부로서
     *    플레이어가 이전에 저장된 상태에서 복원되었는지 여부입니다.
     *    true는 일반적으로 사용자가 재생이 다시 시작될 거라고 예상하는 지점에서 재생을 다시 시작하고
     *    새 동영상이 로드되지 않아야 함을 나타냅니다.
     */

    @Override
    public void onInitializationSuccess(Provider provider,
                                        YouTubePlayer player, boolean wasRestored) {
        if (!wasRestored) {
            //player.cueVideo("wKJ9KzGQq0w"); //video id.

            player.cueVideo("_Ut7YsXmew8");  //http://www.youtube.com/watch?v=IA1hox-v0jQ
         //   player.cueVideo("_Ut7YsXmew8");
         //   player.cueVideo("HtepRj4TzSo");
            //cueVideo(String videoId)
            //지정한 동영상의 미리보기 이미지를 로드하고 플레이어가 동영상을 재생하도록 준비하지만
            //play()를 호출하기 전에는 동영상 스트림을 다운로드하지 않습니다.
            //https://developers.google.com/youtube/android/player/reference/com/google/android/youtube/player/YouTubePlayer
        }
    }

    //플레이어가 초기화되지 못할 때 호출됩니다.
    @Override
    public void onInitializationFailure(YouTubePlayer.Provider provider,
                                        YouTubeInitializationResult errorReason) {
        if (errorReason.isUserRecoverableError()) {
            errorReason.getErrorDialog(this, RECOVERY_DIALOG_REQUEST).show();
        } else {
            String errorMessage = String.format(
                    getString(R.string.error_player), errorReason.toString());
            Toast.makeText(this, errorMessage, Toast.LENGTH_LONG).show();
        }
    }

    protected YouTubePlayer.Provider getYouTubePlayerProvider() {
        return (YouTubePlayerView) findViewById(R.id.youtube_view);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == RECOVERY_DIALOG_REQUEST) {
            // Retry initialization if user performed a recovery action
            getYouTubePlayerProvider().initialize(DeveloperKey.DEVELOPER_KEY, this);
        }
    }
}
