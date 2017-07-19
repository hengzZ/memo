function Plot4Sim(mP1,P1,mP2,P2,mP3,P3,mP4,P4) 

% if mP1 < 2 || mP2 < 2 || mP3 < 2 || mP4 < 2 
%     return;
% end

for i=1:mP1
    if P1(i,3)>4
        plot(P1(i,1),P1(i,2),'sr');hold on;
    else
        plot(P1(i,1),P1(i,2),'or');hold on;
    end        
end
for i=1:mP2
    if P2(i,3)>4
        plot(P2(i,1),P2(i,2),'sb');hold on;
    else
        plot(P2(i,1),P2(i,2),'ob');hold on;
    end        
end
for i=1:mP3
    if P3(i,3)>4
        plot(P3(i,1),P3(i,2),'sg');hold on;
    else
        plot(P3(i,1),P3(i,2),'og');hold on;
    end        
end
for i=1:mP4
    if P4(i,3)>4
        plot(P4(i,1),P4(i,2),'sc');hold on;
    else
        plot(P4(i,1),P4(i,2),'oc');hold on;
    end        
end
% plot(P1(:,1),P1(:,2),'*r');hold on;
% plot(P2(:,1),P2(:,2),'+b');hold on; 
% plot(P3(:,1),P3(:,2),'*g');hold on; 
% plot(P4(:,1),P4(:,2),'+c'); 

spd =200;%mm/s;
wt = 0.50;

P1(1,5) = 0;
P1(1,6) = wt;
P2(1,5) = 0;
P2(1,6) = wt;
P3(1,5) = 0;
P3(1,6) = wt;
P4(1,5) = 0;
P4(1,6) = wt;
for i=2:mP1
    P1(i,5) = norm([P1(i,1)-P1(i-1,1),P1(i,2)-P1(i-1,2)])/spd + P1(i-1,6); 
    P1(i,6) = P1(i,5) + wt; 
end
for i=2:mP2
    P2(i,5) = norm([P2(i,1)-P2(i-1,1),P2(i,2)-P2(i-1,2)])/spd + P2(i-1,6); 
    P2(i,6) = P2(i,5) + wt; 
end
for i=2:mP3
    P3(i,5) = norm([P3(i,1)-P3(i-1,1),P3(i,2)-P3(i-1,2)])/spd + P3(i-1,6); 
    P3(i,6) = P3(i,5) + wt; 
end
for i=2:mP4
    P4(i,5) = norm([P4(i,1)-P4(i-1,1),P4(i,2)-P4(i-1,2)])/spd + P4(i-1,6); 
    P4(i,6) = P4(i,5) + wt; 
end

p1(1,:)=P1(1,:);
p2(1,:)=P2(1,:);
p3(1,:)=P3(1,:);
p4(1,:)=P4(1,:);
i1=1;
i2=1;
i3=1;
i4=1;

p = plot(p1(:,1),p1(:,2),p2(:,1),p2(:,2),p3(:,1),p3(:,2),p4(:,1),p4(:,2),'EraseMode','background');
%axis([0 xlength 0 ywidth]);
txt1 = text(450, 10,'1-2:  ','EraseMode','background');
txt2 = text(450,490,'3-4:  ','EraseMode','background');
txt3 = text(  0,250,'1-3:  ','EraseMode','background');
txt4 = text(830,250,'2-4:  ','EraseMode','background');
txt5 = text(450,240,'1-4:  ','EraseMode','background');
txt6 = text(450,260,'2-3:  ','EraseMode','background');
grid on;

%tmax = ceil(max([P1(mP1,6),P2(mP2,6),P3(mP3,6),P4(mP4,6)]) / 0.1);
tmax = 0 ;
if mP1>0
    if P1(mP1,6)>tmax 
       tmax = P1(mP1,6);
    end
end
if mP2>0
    if P2(mP2,6)>tmax 
       tmax = P2(mP2,6);
    end
end
if mP3>0
    if P3(mP3,6)>tmax 
       tmax = P3(mP3,6);
    end
end
if mP4>0
    if P4(mP4,6)>tmax 
       tmax = P4(mP4,6);
    end
end
tmax = ceil(tmax/0.1);

for i = 1:tmax
    t = i * 0.1;
    if mP1>0
    if i1>=mP1
        p1(mP1,:) = P1(mP1,:);
    else
        if  P1(i1,6)<t && t<P1(i1+1,5)
            p1(i1+1,:) = P1(i1,:) + (t-P1(i1,6))*(P1(i1+1,:)-P1(i1,:)) / norm([P1(i1+1,1)-P1(i1,1),P1(i1+1,2)-P1(i1,2)])*spd;
        elseif P1(i1+1,5)<t && t<P1(i1+1,6)
            p1(i1+1,:) =     P1(i1+1,:);
        elseif t>P1(i1+1,6)
            if i1<mP1 
                i1 = i1 + 1;
            end
        end
    end
    end
    if mP2 >0
    if i2>=mP2
        p2(mP2,:) = P2(mP2,:);        
    else
        if  P2(i2,6)<t && t<P2(i2+1,5)
            p2(i2+1,:) = P2(i2,:) + (t-P2(i2,6)) * (P2(i2+1,:)-P2(i2,:)) / norm([P2(i2+1,1)-P2(i2,1),P2(i2+1,2)-P2(i2,2)])*spd;
        elseif P2(i2+1,5)<t && t<P2(i2+1,6)
            p2(i2+1,:) =     P2(i2+1,:);
        elseif t>P2(i2+1,6)
            if i2<mP2 
                i2 = i2 + 1;
            end
        end
    end
    end
    if mP3>0
    if i3>=mP3
        p3(mP3,:) = P3(mP3,:);
    else
        if  P3(i3,6)<t && t<P3(i3+1,5)
            p3(i3+1,:) = P3(i3,:) + (t-P3(i3,6))*(P3(i3+1,:)-P3(i3,:)) / norm([P3(i3+1,1)-P3(i3,1),P3(i3+1,2)-P3(i3,2)])*spd;
        elseif P3(i3+1,5)<t && t<P3(i3+1,6)
            p3(i3+1,:) =     P3(i3+1,:);
        elseif t>P3(i3+1,6)
            if i3<mP3 
                i3 = i3 + 1;
            end
        end
    end
    end
    if mP4>0
    if i4>=mP4
        p4(mP4,:) = P4(mP4,:);
    else    
        if  P4(i4,6)<t && t<P4(i4+1,5)
            p4(i4+1,:) = P4(i4,:) + (t-P4(i4,6))*(P4(i4+1,:)-P4(i4,:)) / norm([P4(i4+1,1)-P4(i4,1),P4(i4+1,2)-P4(i4,2)])*spd;
        elseif P4(i4+1,5)<t && t<P4(i4+1,6)
            p4(i4+1,:) =     P4(i4+1,:);
        elseif t>P4(i4+1,6)
            if i4<mP4 
                i4 = i4 + 1;
            end
        end
    end    
    end
    set(p(1),'XData',p1(:,1),'YData',p1(:,2))
    set(p(2),'XData',p2(:,1),'YData',p2(:,2))
    set(p(3),'XData',p3(:,1),'YData',p3(:,2))
    set(p(4),'XData',p4(:,1),'YData',p4(:,2))

    textfig1 = ['1-2: ' num2str(round(norm(p1(i1,:)-p2(i2,:)))) 'mm'];
    textfig2 = ['3-4: ' num2str(round(norm(p3(i3,:)-p4(i4,:)))) 'mm'];
    textfig3 = ['1-3: ' num2str(round(norm(p1(i1,:)-p3(i3,:)))) 'mm'];
    textfig4 = ['2-4: ' num2str(round(norm(p2(i2,:)-p4(i4,:)))) 'mm'];
    textfig5 = ['1-4: ' num2str(round(norm(p1(i1,:)-p4(i4,:)))) 'mm'];
    textfig6 = ['2-3: ' num2str(round(norm(p2(i2,:)-p3(i3,:)))) 'mm'];
    
    set(txt1,'String',textfig1);
    set(txt2,'String',textfig2);
    set(txt3,'String',textfig3);
    set(txt4,'String',textfig4);
    set(txt5,'String',textfig5);
    set(txt6,'String',textfig6);
    
    drawnow
    pause(0.1);
end
 
% %%
% % %采用背景擦除的方法，动态的划线，并且动态改变坐标系
% % % 多行划线
% % t=[0];
% % m=[sin(t);cos(t)];
% % p = plot(t,m,...
% %    'EraseMode','background','MarkerSize',5);
% % x=-1.5*pi;
% % axis([x x+2*pi -1.5 1.5]);
% % grid on;
% % for i=1:100
% %     t=[t 0.1*i];                   %Matrix 1*(i+1)
% %     m=[m [sin(0.1*i);cos(0.1*i)]]; %Matrix 2*(i+1)
% %     set(p(1),'XData',t,'YData',m(1,:))
% %     set(p(2),'XData',t,'YData',m(2,:))
% %     drawnow
% %     x=x+0.1;
% %     axis([x x+2*pi -1.5 1.5]);
% %     pause(0.1);
% % end
% 
% %%上面的这几个画图方式的示例只是简单的for循环，是单线程的，如果是涉及到GUI的编程，那么请使用Timer来完成这件事情，Timer是我在Matlab中实现多线程唯一方法(没有找到别的方法)。
