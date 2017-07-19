function PP = Greed2t(np,P);%,stP)
npc = 0;
nps = 0;
PPc=[];
PPs=[];
for i=1:np
    if P(i,3)<5
        npc = npc + 1;
        PPc(npc,:)=P(i,:);
    else
        nps = nps + 1;
        PPs(nps,:)=P(i,:);
    end
end
PPc = Greed(npc,PPc);
PPs = Greed(nps,PPs);
PP = [PPc;PPs];
