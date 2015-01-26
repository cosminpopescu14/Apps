%Tema 1 Prelucrarea semnalelor.(digital signal processing)
%Popescu Ionut Cosmin, 331AC
%modulation of a bit stream using FSK

data = [0 0 1 1 1 0 0 1 1 0 1 0 1 1 0 0 ]; %sirul de biti pe care il vom modula
%stem(data)%reprezentare date.
bit_period = 0.0001;
disp('Mesajul catre transmitatorul FM');%mesage to FM trasmitter
disp(data);


%am reprezentat sirul de biti ca un semnal dreptunghiular
%representation of the bit stream "data" as a rectangular singnal
bit = [];
for n=1 : 1 : length(data)
    if data(n) == 1;
        a = ones(1, 100);
    else data(n) = 0;
        a = zeros(1, 100);
    end
     bit = [bit a];

end

t1 = bit_period / 100 : bit_period/100 : 100 * length(data) * (bit_period/100);
subplot(4,1,1);
plot(t1, bit, 'lineWidth', 3);
grid on;
xlabel('timp');%time
ylabel('amplitudine');%amplitude
title('Datele trimise ca semnal digital');%data as digital signal


%%modularea semnalului
%modulation of signal
bit_rate = 1 / bit_period;
frecv_bit_0 = bit_rate * 8;
frecv_bit_1 = bit_rate * 32;
t2 = bit_period / 99 : bit_period / 99 : bit_period;
b = length(t2);%signal size
signal = [];

for i = 1 : 1 : length(data)
    if(data(i) == 1)
        y = sin(2 * pi * frecv_bit_0 * t2);
    else
        y = sin(2 * pi * frecv_bit_1 * t2);
    end
    signal = [signal, y];
end

t3 = bit_period / 99 : bit_period / 99 : bit_period * length(data);
b1 = length(t3);
subplot(4, 1, 2);
plot(t3, signal);
title('date modulate FM');


%adaugare zgomot peste semnalul modulat
% awgn - add white gaussian noise
noisy_signal = awgn(signal, 1.5);
subplot(4, 1, 3);
plot(noisy_signal);


%demodulare
%demodulation
mn = [];
for n = b : b : length(noisy_signal)
    t = bit_period / 99 : bit_period / 99 : bit_period;
    y1 = sin(2 * pi * frecv_bit_0 * t2);
    y2 = sin(2 * pi * frecv_bit_1 * t2);
    
    c = y1.*noisy_signal((n-(b-1)):n);
    c1 = y2.*noisy_signal((n-(b-1)):n);
    t4 = bit_period / 99 : bit_period / 99 : bit_period;
    
    z1 = trapz(t4, c); %integrare dupa t4 a semnalelor fm 
    z2 = trapz(t4, c1);
    z3 = round(2 * z1 / bit_period);
    z4 = round(2 * z2 / bit_period);
    
    if(z3 > 0.5)%amplitudianea semnalului este 1 %comparatorul
        digital_signal = 1;
    else (z4 > 0.5)
          digital_signal = 0;
    end
    
    mn = [mn, digital_signal];
end
disp('Semnalul digital reconstruit');
disp(mn);

%reprezentare informatia binra
%display bitstream as individual bits
bit = [];
for n=1 : 1 : length(data)
    if data(n) == 1;
        a = ones(1, 100);
    else data(n) = 0;
        a = zeros(1, 100);
    end
     bit = [bit a];

end
t1 = bit_period / 100 : bit_period/100 : 100 * length(mn) * (bit_period/100);
subplot(4,1,4);
plot(t1, bit, 'lineWidth', 3);
grid on;
xlabel('timp');
ylabel('amplitudine');
title('Datele receptionate');
