--select * from [CoreUis].dbo.psc_urm_Form
--delete from [CoreUis].dbo.psc_urm_Form where ModuleID = 'CMS'

insert into [CoreUis].dbo.psc_urm_Form(FormID, FormName, ModuleID)
select FormID, FormName, 'CMS' 
from psc_CMS_Forms

--select * from [CoreUis].dbo.psc_urm_FormObject
--delete from [CoreUis].dbo.psc_urm_FormObject

insert into [CoreUis].dbo.psc_urm_FormObject(FormID, ControlID, ObjectName)
select FormID, ControlID, ObjectName
from #temp

select *
into #temp
from psc_CMS_FormObjects
where FormID = 'rfrm_CMS_Main' 
	and TypeObject in ('BarButtonItemLink', 'BarSubItemLink', 'BarButtonItem')

select *
--into #temp
from psc_CMS_FormObjects
where FormID = 'rfrm_CMS_Main' and ObjectName like '%Upload%'
	and TypeObject in ('BarButtonItemLink', 'BarSubItemLink', 'BarButtonItem')