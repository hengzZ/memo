clc;
clear;

xlength = 900;%x
ywidth  = 500;%y
yover = 000;
minidistP2P = 40;
NumofP = 160;
if(ywidth * xlength / minidistP2P / minidistP2P) < 1.5 * NumofP;
    NumofP = floor(ywidth * xlength / minidistP2P / minidistP2P /1.5);
end

[mPLB,PLB,mPRB,PRB,mPLU,PLU,mPRU,PRU] = RandHandian(xlength,ywidth,yover,minidistP2P,NumofP);
figure(1);clf(1);
% [nplbc,PLBc,nplbs,PLBs] = Greed2t(mPLB,PLB); 
% [nprbc,PRBc,nprbs,PRBs] = Greed2t(mPRB,PRB); 
% [npluc,PLUc,nplus,PLUs] = Greed2t(mPLU,PLU); 
% [npruc,PRUc,nprus,PRUs] = Greed2t(mPRU,PRU); 
% Plot4Sim(nplbc,PLBc,nprbc,PRBc,npluc,PLUc,npruc,PRUc); hold on;
% Plot4Sim(nplbs,PLBs,nprbs,PRBs,nplus,PLUs,nprus,PRUs); 
PLB = Greed2t(mPLB,PLB); 
PRB = Greed2t(mPRB,PRB); 
PLU = Greed2t(mPLU,PLU); 
PRU = Greed2t(mPRU,PRU); 
% plot(PLB(:,1),PLB(:,2),'*r-');hold on; 
% plot(PRB(:,1),PRB(:,2),'+b-');hold on; 
% plot(PLU(:,1),PLU(:,2),'*g-');hold on; 
% plot(PRU(:,1),PRU(:,2),'+c-'); 
Plot4Sim(mPLB,PLB,mPRB,PRB,mPLU,PLU,mPRU,PRU); 

%·ÖÈý×é
[nplb1,PLB1,nplb2,PLB2,nplb3,PLB3] = ThreeGroup(mPLB,PLB); 
[nprb1,PRB1,nprb2,PRB2,nprb3,PRB3] = ThreeGroup(mPRB,PRB); 
[nplu1,PLU1,nplu2,PLU2,nplu3,PLU3] = ThreeGroup(mPLU,PLU); 
[npru1,PRU1,npru2,PRU2,npru3,PRU3] = ThreeGroup(mPRU,PRU); 

figure(2);clf(2);
% [nplb1c,PLB1c,nplb1s,PLB1s] = Greed2t(nplb1,PLB1); 
% [nprb2c,PRB2c,nprb2s,PRB2s] = Greed2t(nprb2,PRB2); 
% [nplu1c,PLU1c,nplu1s,PLU1s] = Greed2t(nplu1,PLU1); 
% [npru2c,PRU2c,npru2s,PRU2s] = Greed2t(npru2,PRU2); 
% Plot4Sim(nplb1c,PLB1c,nprb2c,PRB2c,nplu1c,PLU1c,npru2c,PRU2c); hold on;
% Plot4Sim(nplb1s,PLB1s,nprb2s,PRB2s,nplu1s,PLU1s,npru2s,PRU2s); 

PLB1 = Greed2t(nplb1,PLB1); 
PRB2 = Greed2t(nprb2,PRB2); 
PLU1 = Greed2t(nplu1,PLU1); 
PRU2 = Greed2t(npru2,PRU2); 
% plot(PLB1(:,1),PLB1(:,2),'*r-');hold on; 
% plot(PRB2(:,1),PRB2(:,2),'+b-');hold on; 
% plot(PLU1(:,1),PLU1(:,2),'*g-');hold on; 
% plot(PRU2(:,1),PRU2(:,2),'+c-'); 
Plot4Sim(nplb1,PLB1,nprb2,PRB2,nplu1,PLU1,npru2,PRU2); 

figure(3);clf(3);
% [nplb2c,PLB2c,nplb2s,PLB2s] = Greed2t(nplb2,PLB2); 
% [nprb3c,PRB3c,nprb3s,PRB3s] = Greed2t(nprb3,PRB3); 
% [nplu2c,PLU2c,nplu2s,PLU2s] = Greed2t(nplu2,PLU2); 
% [npru3c,PRU3c,npru3s,PRU3s] = Greed2t(npru3,PRU3); 
% Plot4Sim(nplb2c,PLB2c,nprb3c,PRB3c,nplu2c,PLU2c,npru3c,PRU3c); hold on;
% Plot4Sim(nplb2s,PLB2s,nprb3s,PRB3s,nplu2s,PLU2s,npru3s,PRU3s); 

PLB2 = Greed2t(nplb2,PLB2); 
PRB3 = Greed2t(nprb3,PRB3); 
PLU2 = Greed2t(nplu2,PLU2); 
PRU3 = Greed2t(npru3,PRU3); 
% if nplb2 >0 
%     plot(PLB2(:,1),PLB2(:,2),'*r-');hold on; 
% end;
% if nprb3 >0 
%     plot(PRB3(:,1),PRB3(:,2),'+b-');hold on; 
% end
% if nplu2>0
%     plot(PLU2(:,1),PLU2(:,2),'*g-');hold on; 
% end
% if npru3>0
%     plot(PRU3(:,1),PRU3(:,2),'+c-'); 
% end
Plot4Sim(nplb2,PLB2,nprb3,PRB3,nplu2,PLU2,npru3,PRU3); 


figure(4);clf(4);
% [nplb3c,PLB3c,nplb3s,PLB3s] = Greed2t(nplb3,PLB3); 
% [nprb1c,PRB1c,nprb1s,PRB1s] = Greed2t(nprb1,PRB1); 
% [nplu3c,PLU3c,nplu3s,PLU3s] = Greed2t(nplu3,PLU3); 
% [npru1c,PRU1c,npru1s,PRU1s] = Greed2t(npru1,PRU1); 
% Plot4Sim(nplb3c,PLB3c,nprb1c,PRB1c,nplu3c,PLU3c,npru1c,PRU1c); hold on;
% Plot4Sim(nplb3s,PLB3s,nprb1s,PRB1s,nplu3s,PLU3s,npru1s,PRU1s); 
PLB3 = Greed2t(nplb3,PLB3); 
PRB1 = Greed2t(nprb1,PRB1); 
PLU3 = Greed2t(nplu3,PLU3); 
PRU1 = Greed2t(npru1,PRU1);
% if nplb3>0
%     plot(PLB3(:,1),PLB3(:,2),'*r-');hold on; 
% end
% if nprb1>0
%     plot(PRB1(:,1),PRB1(:,2),'+b-');hold on; 
% end
% if nplu3>0
%     plot(PLU3(:,1),PLU3(:,2),'*g-');hold on; 
% end
% if npru1>0
%     plot(PRU1(:,1),PRU1(:,2),'+c-'); 
% end
Plot4Sim(nplb3,PLB3,nprb1,PRB1,nplu3,PLU3,npru1,PRU1); 
