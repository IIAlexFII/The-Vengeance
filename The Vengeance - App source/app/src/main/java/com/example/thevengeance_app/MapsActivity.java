package com.example.thevengeance_app;

import androidx.annotation.NonNull;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.FragmentActivity;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.util.Log;
import android.widget.TextView;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.CircleOptions;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

public class MapsActivity extends FragmentActivity implements OnMapReadyCallback {
    GoogleMap map;
    TextView gold;

    LocationManager locationManager;
    LocationListener locationListener;

    SupportMapFragment mapFragment;

    JSONArray PlayerGold = null;

    public boolean click = false;

    LatLng circleLocation = new LatLng(38.706724, -9.152564);
    LatLng userLocation;

    Intent intent = getIntent();
    String ip = intent.getStringExtra("Ip");
    String id = intent.getStringExtra("Id");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);

        gold = findViewById(R.id.textViewGoldValue);

        mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map);
        mapFragment.getMapAsync(MapsActivity.this);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResult) //works
    {
        super.onRequestPermissionsResult(requestCode, permissions, grantResult);
        if(grantResult.length > 0 && grantResult[0] == PackageManager.PERMISSION_GRANTED)
        {
            if(ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED)
            {
                locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER , 0, 0, locationListener);
            }
        }
    }

    @Override
    public void onMapReady(GoogleMap googleMap) {
        map = googleMap;

        locationManager = (LocationManager) this.getSystemService(Context.LOCATION_SERVICE);
        locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(@NonNull Location location) { //markers don't show up if player position is on
                map.clear();

                userLocation = new LatLng(location.getLatitude(), location.getLongitude());
                Marker user = map.addMarker(new MarkerOptions().position(userLocation).title("My Location"));
                user.setTag("player");
                //map.moveCamera(CameraUpdateFactory.newLatLngZoom(userLocation));

                //Access location info
                Geocoder myGeocoder = new Geocoder(getApplicationContext(), Locale.getDefault());

                try {
                    List<Address> addressList = myGeocoder.getFromLocation(userLocation.latitude, userLocation.longitude, 1);
                    if (addressList != null && addressList.size() != 0) {
                        Log.i("place info", addressList.get(0).toString());
                        String address = "";
                        address += "POSTAL CODE => " + addressList.get(0).getPostalCode();
                        Log.i("ADDRESS", address);
                    }
                } catch (Exception e) {

                }
                //Player radius
                map.addCircle(
                        new CircleOptions()
                                .center(circleLocation)
                                .radius(500.0)
                                .strokeWidth(2)
                                .strokeColor(Color.BLUE)
                                .fillColor(Color.argb(70,50,50,150))
                );

                circleLocation = userLocation;

                //Markers------------------------------------------------------------------------------------------------------
                //it now works with the player position
                // CASTLES
                LatLng CasteloDeSaoJorge = new LatLng(38.713919740635376, -9.13351087225462);
                Marker Castelo1 = map.addMarker(new MarkerOptions().position(CasteloDeSaoJorge).title("Castelo de São Jorge").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo1.setTag("closed");

                LatLng MuralhasdoCastelodeAlmada = new LatLng(38.68445524028011, -9.156058866982177);
                Marker Castelo2 = map.addMarker(new MarkerOptions().position(MuralhasdoCastelodeAlmada).title("Muralhas do Castelo de Almada").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo2.setTag("closed");

                LatLng CastelodosMouros = new LatLng(38.79372670713041, -9.389766753800398);
                Marker Castelo3 = map.addMarker(new MarkerOptions().position(CastelodosMouros).title("Castelo dos Mouros").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo3.setTag("closed");

                LatLng JardimdaQuintadosSeteCastelos = new LatLng(38.68771748575957, -9.310043848769524);
                Marker Castelo4 = map.addMarker(new MarkerOptions().position(JardimdaQuintadosSeteCastelos).title("Jardim da Quinta dos Sete Castelos").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo4.setTag("closed");

                LatLng CastelodeSesimbra = new LatLng(38.45392168347851, -9.106581377620305);
                Marker Castelo5 = map.addMarker(new MarkerOptions().position(CastelodeSesimbra).title("Castelo de Sesimbra").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo5.setTag("closed");

                LatLng JardimdoCastelodeSaoJorge = new LatLng(38.713767475631414, -9.13365182602953);
                Marker Castelo6 = map.addMarker(new MarkerOptions().position(JardimdoCastelodeSaoJorge).title("Jardim do Castelo de São Jorge").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo6.setTag("closed");

                LatLng AssociacaoPortuguesadosAmigosdosCastelos = new LatLng(38.71535007270696, -9.137965922504304);
                Marker Castelo7 = map.addMarker(new MarkerOptions().position(AssociacaoPortuguesadosAmigosdosCastelos).title("ASSOCIAÇÃO PORTUGUESA DOS AMIGOS DOS CASTELOS").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo7.setTag("closed");

                LatLng CastelodePalmela = new LatLng(38.56773392929977, -8.90067556174037);
                Marker Castelo8 = map.addMarker(new MarkerOptions().position(CastelodePalmela).title("Castelo de Palmela").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo8.setTag("closed");

                LatLng CastelodeNisa = new LatLng(38.486717947494434, -9.123136177620305);
                Marker Castelo9 = map.addMarker(new MarkerOptions().position(CastelodeNisa).title("Castelo de Nisa").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo9.setTag("closed");

                LatLng SeteCastelos = new LatLng(38.688413693254965, -9.309677383669746);
                Marker Castelo10 = map.addMarker(new MarkerOptions().position(SeteCastelos).title("Sete Castelos").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo10.setTag("closed");

                LatLng CastelodeAlvercadoRibatejo = new LatLng(38.90205180821504, -9.035722095646625);
                Marker Castelo11 = map.addMarker(new MarkerOptions().position(CastelodeAlvercadoRibatejo).title("Castelo de Alverca do Ribatejo").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo11.setTag("closed");

                LatLng GaleriaMunicipaldoCastelodePirescouxe = new LatLng(38.837786187571716, -9.086898181913075);
                Marker Castelo12 = map.addMarker(new MarkerOptions().position(GaleriaMunicipaldoCastelodePirescouxe).title("Galeria Municipal do Castelo de Pirescouxe").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo12.setTag("closed");

                LatLng CastelodeTorresVedras = new LatLng(39.09587322829467, -9.26128246174037);
                Marker Castelo13 = map.addMarker(new MarkerOptions().position(CastelodeTorresVedras).title("Castelo de Torres Vedras").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo13.setTag("closed");

                LatLng CastelodePortodeMos = new LatLng(39.60428005526965, -8.814578327406496);
                Marker Castelo14 = map.addMarker(new MarkerOptions().position(CastelodePortodeMos).title("Castelo de Porto de Mós").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo14.setTag("closed");

                LatLng CastelodeArraiolos = new LatLng(38.72641221192346, -7.9861687480068175);
                Marker Castelo15 = map.addMarker(new MarkerOptions().position(CastelodeArraiolos).title("Castelo de Arraiolos").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo15.setTag("closed");

                LatLng CastelodeAlmourol = new LatLng(39.4638981993714, -8.379963488779849);
                Marker Castelo16 = map.addMarker(new MarkerOptions().position(CastelodeAlmourol).title("Castelo de Almourol").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Castelo16.setTag("closed");

                //CHURCHES
                LatLng CoventoSantosONovo = new LatLng(38.72127502298326, -9.117655157980732);
                Marker Igreja1 = map.addMarker(new MarkerOptions().position(CoventoSantosONovo).title("Convento Santos-o-Novo").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja1.setTag("closed");

                LatLng IgrejadeSaoNicolau = new LatLng(38.711803595160745, -9.13695291798767);
                Marker Igreja2 = map.addMarker(new MarkerOptions().position(IgrejadeSaoNicolau).title("Igreja de São Nicolau").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja2.setTag("closed");

                LatLng IgrejadoSantissimoSacramento = new LatLng(38.71207148994217, -9.14047197617023);
                Marker Igreja3 = map.addMarker(new MarkerOptions().position(IgrejadoSantissimoSacramento).title("Igreja do Santíssimo Sacramento").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja3.setTag("closed");

                LatLng IgrejadeSaoDomingos = new LatLng(38.71562100110492, -9.138755362485252);
                Marker Igreja4 = map.addMarker(new MarkerOptions().position(IgrejadeSaoDomingos).title("Igreja de São Domingos").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja4.setTag("closed");

                LatLng IgrejadeSantoAntoniodeLisboa = new LatLng(38.71072271806479, -9.133771667086206);
                Marker Igreja5 = map.addMarker(new MarkerOptions().position(IgrejadeSantoAntoniodeLisboa).title("Igreja de Santo António de Lisboa").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja5.setTag("closed");

                LatLng IgrejadeNossaSenhoradaConceicaoVelha = new LatLng(38.70935900882858, -9.13429216660351);
                Marker Igreja6 = map.addMarker(new MarkerOptions().position(IgrejadeNossaSenhoradaConceicaoVelha).title("Igreja de Nossa Senhora da Conceição Velha").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja6.setTag("closed");

                LatLng IgrejadeSantaCatarina = new LatLng(38.711904055909834, -9.14836839939313);
                Marker Igreja7 = map.addMarker(new MarkerOptions().position(IgrejadeSantaCatarina).title("Igreja de Santa Catarina").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja7.setTag("closed");

                LatLng IgrejadeSaoPaulo = new LatLng(38.70848126183515, -9.145176369496827);
                Marker Igreja8 = map.addMarker(new MarkerOptions().position(IgrejadeSaoPaulo).title("Igreja de São Paulo").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja8.setTag("closed");

                LatLng IgrejaeConventodoMeninoDeus = new LatLng(38.71428158367014, -9.13103060068428);
                Marker Igreja9 = map.addMarker(new MarkerOptions().position(IgrejaeConventodoMeninoDeus).title("Igreja e Convento do Menino Deus").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja9.setTag("closed");

                LatLng IgrejaParoquialdeSaoCristovaoeSaoLourenco = new LatLng(38.71337746271298, -9.135880034481557);
                Marker Igreja10 = map.addMarker(new MarkerOptions().position(IgrejaParoquialdeSaoCristovaoeSaoLourenco).title("Igreja Paroquial de São Cristóvão e São Lourenço").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja10.setTag("closed");

                LatLng IgrejadeSantiago = new LatLng(38.712272410457714, -9.130773108624247);
                Marker Igreja11 = map.addMarker(new MarkerOptions().position(IgrejadeSantiago).title("Igreja de Santiago").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja11.setTag("closed");

                LatLng IgrejadeSaoVicentedeFora = new LatLng(38.71552054566792, -9.127726119247196);
                Marker Igreja12 = map.addMarker(new MarkerOptions().position(IgrejadeSaoVicentedeFora).title("Igreja de São Vicente de Fora").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja12.setTag("closed");

                LatLng CapeladeNossaSenhoradaOliveira = new LatLng(38.709794352267075, -9.13789705561398);
                Marker Igreja13 = map.addMarker(new MarkerOptions().position(CapeladeNossaSenhoradaOliveira).title("Capela de Nossa Senhora da Oliveira").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja13.setTag("closed");

                LatLng IgrejadeSãoJosedosCarpinteiros = new LatLng(38.72020831562114, -9.143433134909175);
                Marker Igreja14 = map.addMarker(new MarkerOptions().position(IgrejadeSãoJosedosCarpinteiros).title("Igreja de São José dos Carpinteiros").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja14.setTag("closed");

                LatLng IgrejadeNossaSenhoradaVitoria = new LatLng(38.71146872526568, -9.139012854488612);
                Marker Igreja15 = map.addMarker(new MarkerOptions().position(IgrejadeNossaSenhoradaVitoria).title("Igreja de Nossa Senhora da Vitória").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja15.setTag("closed");

                LatLng IgrejadeNossaSenhoradaEncarnacao = new LatLng(38.710932930169655, -9.142660658730875);
                Marker Igreja16 = map.addMarker(new MarkerOptions().position(IgrejadeNossaSenhoradaEncarnacao).title("Igreja de Nossa Senhora da Encarnação").icon(BitmapDescriptorFactory.fromResource(R.drawable.close)));
                Igreja16.setTag("closed");


                //Click markers
                map.setOnMarkerClickListener(new GoogleMap.OnMarkerClickListener() {

                    @Override
                    public boolean onMarkerClick(Marker marker) {
                            if (marker.getTag().toString().equals("player")) { //works
                                Log.i("No valid pos", "No gold");
                            } else { //works
                                int goldvalue = Integer.parseInt(gold.getText().toString());
                                goldvalue = goldvalue + 10;
                                gold.setText("" + goldvalue);
                                click = true;

                            //Doesn't work
                            try {
                                // -------------> POST DATA

                                Map<String, Integer> postData = new HashMap<>();
                                postData.put("gold", goldvalue);

                                PostGold task = new PostGold(postData);
                                task.execute(ip + ":3434/updategold"); //put var to the ip


                            } catch (Exception e) {
                                e.printStackTrace();
                                PlayerGold = null;
                            }
                            }
                        return false;
                    }
                });

                //Doesn't work
                if (click == true) {
                    new CountDownTimer(10000, 1000) {
                        @Override
                        public void onTick(long l) {
                            Log.i("Seconds Left:", String.valueOf(l / 1000));
                        }

                        @Override
                        public void onFinish() {
                            Log.i("We're done!!", "No more seconds");
                            click = false;
                        }
                    }.start();
                }

            }

            @Override
            public void onStatusChanged(String s, int i, Bundle bundle) {

            }

            @Override
            public void onProviderEnabled(String s) {

            }

            @Override
            public void onProviderDisabled(String s) {

            }
        };

        if (ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER,0,0,locationListener);
        } else {
            ActivityCompat.requestPermissions(this,new String[]{Manifest.permission.ACCESS_FINE_LOCATION},1);
        }
    }
}


