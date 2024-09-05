Feature: CreateNewPurchaseRequisition

Login into the Workbench system using
credentials, then create and verify 
Purchase Requisition using specified 
arguments. (4 Test cases provided.)

Background: 
	Given I am at the Workbench login screen
	And I log in as 'wbadmin' user

Scenario: The user can navigate to the Create Purchase Requisitions screen 
	When I click on button by id 'sidebar-collapse'
	When I click on button by id 'Purchasing'
	And I click on button by id 'Purchase_Requisitions'
	And I click on button by id 'siteMapItem_Purchase_Requisitions_List'
	Then The screen title is 'Local Workbench — Purchase Requisitions'

Scenario: The user can input the header and details then clicks save button
	When I navigate into the Purchase Requisitions screen
	Then The screen title is 'Local Workbench — Purchase Requisitions'
	When I click on button by id 'New'
	And I input 'Automation test' into the text box with id 'GeneralFields_Description'
	And I input '4112' into the text box with id 'GeneralFields_Job'
	And I click on '4112' item from UI autocomplete
	And I click on button by id 'addressesSection'
	And I input '3 test drive' into the text box with id 'AddressesFields_DeliveryAddress'
	And I input '05-Sep-2024' into the text box with id 'AddressesFields_RequiredDate'
	And I click on button by id 'newLine_RequisitionDetail'
	And I input 'ACCOM' into the text box with id 'RequisitionDetail_ActivityCode_Picker'
	And I click on 'ACCOM' item from UI autocomplete
	And I input 'Workbench Employee' into the text box with id 'text_Details'
	And I input '2' into the text box with id 'numText_Quantity'
	And I input '100' into the text box with id 'numText_UnitCost'
	And I click on button by id 'Save'
	Then The purchase requisition success message is displayed

Scenario: The user can submit the PR for Review and Approval
	When I navigate into the Purchase Requisitions
	Then The screen title is 'Local Workbench — Purchase Requisitions'
	When I click on button by id 'New'
	And I input 'Automation test' into the text box with id 'GeneralFields_Description'
	And I input '4112' into the text box with id 'GeneralFields_Job'
	And I click on '4112' item from UI autocomplete
	And I click on button by id 'addressesSection'
	And I input '3 test drive' into the text box with id 'AddressesFields_DeliveryAddress'
	And I input '05-Sep-2024' into the text box with id 'AddressesFields_RequiredDate'
	And I click on button by id 'newLine_RequisitionDetail'
	And I input 'ACCOM' into the text box with id 'RequisitionDetail_ActivityCode_Picker'
	And I click on 'ACCOM' item from UI autocomplete
	And I input 'Workbench Employee' into the text box with id 'text_Details'
	And I input '2' into the text box with id 'numText_Quantity'
	And I input '100' into the text box with id 'numText_UnitCost'
	And I click on button by id 'Save'
	Then The purchase requisition success message is displayed
	When I click on button by id 'Submit'
	Then The 'Confirm Submission' pop-up is displayed
	When I click on button with text 'Confirm'
	Then The screen title is 'Local Workbench — Purchase Requisitions'

Scenario: Verify error message if Purchase Requisition is incomplete. And check user is able to assign a person
	When I navigate into the Purchase Requisitions
	Then The screen title is 'Local Workbench — Purchase Requisitions'
	When I click on button by id 'New'
	And I input '4112' into the text box with id 'GeneralFields_Job'
	And I click on '4112' item from UI autocomplete
	And I click on button by id 'addressesSection'
	And I input '3 test drive' into the text box with id 'AddressesFields_DeliveryAddress'
	And I input '05-Sep-2024' into the text box with id 'AddressesFields_RequiredDate'
	And I click on button by id 'newLine_RequisitionDetail'
	And I input 'ACCOM' into the text box with id 'RequisitionDetail_ActivityCode_Picker'
	And I click on 'ACCOM' item from UI autocomplete
	And I input 'Workbench Employee' into the text box with id 'text_Details'
	And I input '2' into the text box with id 'numText_Quantity'
	And I input '100' into the text box with id 'numText_UnitCost'
	And I click on button by id 'Save'
	Then The purchase requisition error message is displayed
	When I click on button by id 'generalSection'
	And I input 'Automation test' into the text box with id 'GeneralFields_Description'
	And I click on button by id 'Save'
	Then The purchase requisition success message is displayed
	When I click on button by id 'Assign'
	Then The 'Assign to Editor/Requester' pop-up is displayed
	When I input 'Bill' into the text box with id 'AssignDialog_Editor'
	And I click on 'Bill' item from UI autocomplete
	And I click on button with text 'Confirm'
	Then The screen title is 'Local Workbench — Purchase Requisitions'