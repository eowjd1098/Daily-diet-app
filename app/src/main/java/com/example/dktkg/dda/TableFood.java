package com.example.dktkg.dda;
import java.io.ByteArrayOutputStream;
import java.io.File;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.Base64;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.MarshalBase64;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import static com.example.dktkg.dda.MainActivity.userid;


/**
 * Created by dktkg on 2017-03-23.
 */

public class TableFood extends Activity{ //implements OnClickListener {

    private static final int PICK_FROM_CAMERA = 0;
    private static final int PICK_FROM_ALBUM = 1;
    private static final int CROP_FROM_CAMERA = 2;

    private Uri mImageCaptureUri;
    private ImageView mPhotoImageView;
    private Button mButton;
    private Button sendButton;

    String id = userid;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
}
        //  setContentView(R.layout.tabletwo);

        //<   mButton = (Button) findViewById(R.id.button);
        //    sendButton = (Button)findViewById(R.id.analysisbutton);
        //    mPhotoImageView = (ImageView) findViewById(R.id.image);

        //    mButton.setOnClickListener(this);

        //    sendButton.setOnClickListener(new View.OnClickListener() {
        //        @Override
        //        public void onClick(View v) {

        //            BitmapDrawable img = (BitmapDrawable)((ImageView) findViewById(R.id.image)).getDrawable();
        //            Bitmap imgBitmap = img.getBitmap();

        //            Foodimg sending = new Foodimg(id,bitmapToByteArray(imgBitmap));
        //            SendingIMG sendingIMG = (SendingIMG) new SendingIMG().execute(sending);
        //        }
        //    });
        //}

        //public class SendingIMG extends AsyncTask<Foodimg,Void,String>{
        //    @Override
        //    protected void onPreExecute() {
        //        super.onPreExecute();
        //    }

        //    @Override
        //    protected String doInBackground(Foodimg... params) {
        //        //서버 호출
        //        Connect con = new Connect("ImageAnalysis");
        //        SoapObject request = new SoapObject(con.getNamespace(),con.getMethodname());
        //        request.addProperty("id",params[0].getId());
        //        request.addProperty("img",params[0].getImg());

        //        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        //        envelope.setOutputSoapObject(request);
        //        envelope.dotNet=true;
        //        new MarshalBase64().register(envelope);
        //        HttpTransportSE post = new HttpTransportSE(con.getUrl());

        //        String result="";
        //        try {
        //            post.call(con.getSaopaction(),envelope);
        //            result = envelope.getResponse().toString();
        //        }catch (Exception e){
        //            result = e.toString();
        //        }
        //        return result;
        //    }
        //    @Override
        //    protected void onPostExecute(String s) {
        //        super.onPostExecute(s);
        //        //결과값은 고민후 진행
        //        String checklogin=s;

        //        if(checklogin.equals("0")) {
        //            Toast.makeText(TableFood.this, "오류없음 ", Toast.LENGTH_SHORT).show();
        //        }else{
        //            Toast.makeText(TableFood.this, "오류많음 ", Toast.LENGTH_SHORT).show();
        //        }


        //    }
        //}


        //// 이미지 변환 메소드
        //public byte[] bitmapToByteArray( Bitmap $bitmap ) {
        //    ByteArrayOutputStream stream = new ByteArrayOutputStream() ;
        //    $bitmap.compress( Bitmap.CompressFormat.PNG, 50, stream) ;
        //    byte[] byteArray = stream.toByteArray() ;
        //    return byteArray ;
        //}

        ///**
        // * 카메라에서 이미지 가져오기
        // */
        //rivate void doTakePhotoAction(){
        //   Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        //   // 임시로 사용할 파일의 경로를 생성
        //   String url = "tmp_" + String.valueOf(System.currentTimeMillis()) + ".jpg";
        //   mImageCaptureUri = Uri.fromFile(new File(Environment.getExternalStorageDirectory(), url));

        //   intent.putExtra(android.provider.MediaStore.EXTRA_OUTPUT, mImageCaptureUri);
        //   // 특정기기에서 사진을 저장못하는 문제가 있어 다음을 주석처리 합니다.
        //   // intent.putExtra("return-data", true);
        //   startActivityForResult(intent, PICK_FROM_CAMERA);
        //

        ///**
        // * 앨범에서 이미지 가져오기
        // */
        //private void doTakeAlbumAction(){
        //    // 앨범 호출
        //    Intent intent = new Intent(Intent.ACTION_PICK);
        //    intent.setType(android.provider.MediaStore.Images.Media.CONTENT_TYPE);
        //    startActivityForResult(intent, PICK_FROM_ALBUM);
        //}

        //@Override
        //protected void onActivityResult(int requestCode, int resultCode, Intent data){
        //    if(resultCode != RESULT_OK)
        //    {
        //        return;
        //    }

        //    switch(requestCode)
        //    {
        //        case CROP_FROM_CAMERA:
        //        {
        //            // 크롭이 된 이후의 이미지를 넘겨 받습니다.
        //            // 이미지뷰에 이미지를 보여준다거나 부가적인 작업 이후에
        //            // 임시 파일을 삭제합니다.
        //            final Bundle extras = data.getExtras();

        //            if(extras != null)
        //            {
        //                Bitmap photo = extras.getParcelable("data");
        //                mPhotoImageView.setImageBitmap(photo);
        //            }

        //            // 임시 파일 삭제
        //            File f = new File(mImageCaptureUri.getPath());
        //            if(f.exists())
        //            {
        //                f.delete();
        //            }

        //            break;
        //        }

        //        case PICK_FROM_ALBUM:
        //        {
        //            // 이후의 처리가 카메라와 같으므로 일단  break없이 진행합니다.
        //            // 실제 코드에서는 좀더 합리적인 방법을 선택하시기 바랍니다.

        //            mImageCaptureUri = data.getData();
        //        }

        //        case PICK_FROM_CAMERA:
        //        {
        //            // 이미지를 가져온 이후의 리사이즈할 이미지 크기를 결정합니다.
        //            // 이후에 이미지 크롭 어플리케이션을 호출하게 됩니다.

        //            Intent intent = new Intent("com.android.camera.action.CROP");
        //            intent.setDataAndType(mImageCaptureUri, "image/*");

        //            intent.putExtra("outputX", 200);
        //            intent.putExtra("outputY", 150);
        //            intent.putExtra("aspectX", 0);
        //            intent.putExtra("aspectY", 0);
        //            intent.putExtra("scale", true);
        //            intent.putExtra("return-data", true);
        //            startActivityForResult(intent, CROP_FROM_CAMERA);

        //            break;
        //        }
        //    }
        //}

        //@Override
        //public void onClick(View v) {
        //    DialogInterface.OnClickListener cameraListener = new DialogInterface.OnClickListener()
        //    {
        //       @Override
        //       public void onClick(DialogInterface dialog, int which)
        //       {
        //           doTakePhotoAction();
        //       }
        //    };

        //    DialogInterface.OnClickListener albumListener = new DialogInterface.OnClickListener()
        //    {
        //        @Override
        //        public void onClick(DialogInterface dialog, int which)
        //        {
        //            doTakeAlbumAction();
        //        }
        //    };

        //    DialogInterface.OnClickListener cancelListener = new DialogInterface.OnClickListener()
        //    {
        //        @Override
        //        public void onClick(DialogInterface dialog, int which)
        //        {
        //            dialog.dismiss();
        //        }
        //    };

        //    new AlertDialog.Builder(this)
        //            .setTitle("업로드할 이미지 선택")
        //            .setPositiveButton("사진촬영", cameraListener)
        //            .setNeutralButton("앨범선택", albumListener)
        //            .setNegativeButton("취소", cancelListener)
        //            .show();


